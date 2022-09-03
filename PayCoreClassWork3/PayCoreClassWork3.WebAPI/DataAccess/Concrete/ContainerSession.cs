using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;
using ISession = NHibernate.ISession;

namespace PayCoreClassWork3.WebAPI.DataAccess.Concrete
{
    // Bütün ortak veritabanı işlemleri CoreSession'dan uygun tabloya karşılık gelecek olan veri tipinden generic bir şekilde kalıtım alınır.
    // Mevcutta yer alan yalnızca Container sınıfına ait veritabanı işlemleri ise IContainerSession interface'inden implemente edilir.
    public class ContainerSession : CoreSession<Container>, IContainerSession
    {
        // Gerekli kurucu metod eklenir ve CoreSession sınıfının kurucu metoduna ISession nesnesi aktarılır.
        // Böylelikle kalıtım alınma sırasında generic operatör içerisinde belirlenmiş tip için tüm veritabanı işlemlerinin kalıtımı alınır.
        public ContainerSession(ISession session) : base(session)
        {
        }

        // CoreSession'da yer alan virtual metod'un gerekli override işlemleri yapılır.
        // Buradaki ihtiyaç container tablosunda güncelleme yapmaya yönelik işlemlerin ayarlanması oldu.
        public override async Task StartTransactionalOperation(Operation operation, Container entity, Container? entityFromBody = null)
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
                            entity.ContainerName = entityFromBody.ContainerName;
                            entity.Latitude = entityFromBody.Latitude;
                            entity.Longitude = entityFromBody.Longitude;
                            await Update(entity);
                        }
                        break;

                    case Operation.Delete:
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