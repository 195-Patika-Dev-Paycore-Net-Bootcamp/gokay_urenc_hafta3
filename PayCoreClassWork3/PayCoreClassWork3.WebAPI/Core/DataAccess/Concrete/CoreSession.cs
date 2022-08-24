using NHibernate;
using NHibernate.Linq;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;
using System.Linq.Expressions;
using ISession = NHibernate.ISession;

namespace PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete
{
    // Veritabanında yer alan tablolara ait sınıfların session sınıfları bu sınıftan kalıtım alarak ortak veritabanı işlemlerinin tekrar yazılmasına gerek kalmaz.
    // Bütün ortak veritabanı işlemleri ICoreSessin interface'inden implemente edilerek yapacakları görevler belirlenir.
    // CoreSession'un generic operatörünün içerisinde generic bir tip belirlenir. Ancak bu tip yalnızca CoreEntity sınıfından kalıtım almış bir tip olmak zorundadır.
    // Böylelikle bu sınıftan kalıtım alan diğer Session sınıfları kendi veritabanı tablo sınıfı için bu işlemlerin tekrar yazılmasına gerek duymaz.
    public class CoreSession<TEntity> : ICoreSession<TEntity> where TEntity : CoreEntity
    {
        private readonly ISession _session; // NHibernate kütüphanesinden gelen ISession. Veritabanı işlemlerinin implemente edilmesinde kullanılır.
        private ITransaction _transaction; // NHibernate kütüphanesinden gelen ITransaction. Takip işlemlerinin implemente edilmesinde kullanılır.

        public CoreSession(ISession session)
        {
            _session = session;
        }

        // Belli bir filtreye göre veya tüm kayıtları listeleme.
        // Eğer parametrede bir filtre (LINQ sorgusu) belirlenmediyse o tabloya ait tüm kayıtlar listelenir.
        public async Task<IList<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression == null
                ? await _session.Query<TEntity>().ToListAsync()
                : await _session.Query<TEntity>().Where(expression).ToListAsync();
        }

        // Id'ye göre kayıt arama.
        public async Task<TEntity> GetById(long id)
        {
            return await _session.Query<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        // Yeni bir kayıt ekleme.
        public async Task Add(TEntity entity)
        {
            await _session.SaveAsync(entity);
        }

        // Mevcut bir kaydı güncelleme.
        public async Task Update(TEntity entity)
        {
            await _session.UpdateAsync(entity);
        }

        // Mevcut bir kaydı silme.
        public async Task Delete(TEntity entity)
        {
            await _session.DeleteAsync(entity);
        }

        // Takipe alınacak bir işlem başlatma.
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        // Takipe alınan işlemi işleme.
        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        // Takipe alınan işlemi geriye sarma.
        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        // Takip işlemini sona erdirme.
        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        // Bir işlemi takip ettirerek yaptırma.
        // Bu sınıftan kalıtım alan diğer Session sınıfları bu metodu kendi içindeki ihtiyaca göre değiştirebilir.
        // İlk parametresi, takibe alınacak olan işlemin ne tür bir veritabanı işlemi olduğudur.
        // İkinci parametresi, hangi verinin bu işlemde kullanılacağı bilgisidir.
        // Üçüncü parametre ise opsiyonel olan ve request body'den gelecek olan bilgidir. Güncelleme işleminde gerek duyulur.
        // Bütün takip aşamaları yerine getirilerek istenilen veritabanı işlemini gerçekleştirmeye yarar.
        public virtual async Task StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null)
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
                        await Update(entity);
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

    // Takip işleminde ne tür bir veritabanı işleminin takip edileceğini belirlemek için kullanılacak olan enum.
    public enum Operation { Add, Update, Delete }
}