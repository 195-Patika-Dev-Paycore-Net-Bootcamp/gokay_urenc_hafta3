using NHibernate.Linq;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;
using ISession = NHibernate.ISession;

namespace PayCoreClassWork3.WebAPI.DataAccess.Concrete
{
    // Bütün ortak veritabanı işlemleri CoreSession'dan uygun tabloya karşılık gelecek olan veri tipinden generic bir şekilde kalıtım alınır.
    // Mevcutta yer alan yalnızca Vehicle sınıfına ait veritabanı işlemleri ise IVehicleSession interface'inden implemente edilir.
    public class VehicleSession : CoreSession<Vehicle>, IVehicleSession
    {
        private readonly ISession _session;

        // Gerekli kurucu metod eklenir ve CoreSession sınıfının kurucu metoduna ISession nesnesi aktarılır.
        // Böylelikle kalıtım alınma sırasında generic operatör içerisinde belirlenmiş tip için tüm veritabanı işlemlerinin kalıtımı alınır.
        public VehicleSession(ISession session) : base(session)
        {
            _session = session;
        }

        // CoreSession'da yer alan virtual metod'un gerekli override işlemleri yapılır.
        // Buradaki ihtiyaç vehicle tablosunda güncelleme yapmaya yönelik işlemlerin ayarlanması ve bir araç silindiğinde ondan önce o araca ait konteynerlerin silinmesiyle beraber toplu bir transaction yönetimi sağlanması oldu.
        public override async Task StartTransactionalOperation(Operation operation, Vehicle entity, Vehicle? entityFromBody = null)
        {
            try
            {
                BeginTransaction();

                switch (operation)
                {
                    case Operation.Add:
                        await Add(entity);
                        break;

                    case Operation.Update:
                        if (entityFromBody != null)
                        {
                            entity.VehicleName = entityFromBody.VehicleName;
                            entity.VehiclePlate = entityFromBody.VehiclePlate;
                            await Update(entity);
                        }
                        break;

                    case Operation.Delete:
                        var containers = await _session.Query<Container>().Where(c => c.VehicleId == entity.Id).ToListAsync();
                        for (int i = 0; i < containers.Count; i++)
                        {
                            await _session.DeleteAsync(containers[i]);
                        }
                        await Delete(entity);
                        break;
                }

                await CommitTransaction();
            }
            catch
            {
                await RollbackTransaction();
            }
            finally
            {
                CloseTransaction();
            }
        }
    }
}