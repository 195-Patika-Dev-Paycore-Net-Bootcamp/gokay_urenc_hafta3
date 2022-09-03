using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;
using System.Linq.Expressions;

namespace PayCoreClassWork3.WebAPI.Core.Business.Abstract
{
    // Tüm veritabanı nesnelerine hizmet edecek ortak servis metodları burada yer alır.
    // ICoreSession interface'si ile aynı isimde metodlara sahiptir. Ancak bu metodlar servis görevi görmektedir.
    // Bir servis nesnesine erişilerek o nesneye ait session sınıfındaki metodlarada erişilmesi amaçlanmıştır.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmalıdır.
    public interface IService<TEntity> where TEntity : CoreEntity
    {
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null);
        Task<TEntity> GetById(long id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        void BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
        void CloseTransaction();
        Task StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null);
    }
}