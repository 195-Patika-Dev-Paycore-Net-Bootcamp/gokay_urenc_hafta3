using PayCoreClassWork3.WebAPI.Core.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;
using System.Linq.Expressions;

namespace PayCoreClassWork3.WebAPI.Core.Business.Concrete
{
    // Bütün ortak veritabanı ve servis işlemlerinin yer aldığı en genel iş sınıfıdır.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmalıdır.
    // TSession, belirlenen TEntity nesnesine ait uygun session nesnesi olmalıdr. Aksi halde hata verir.
    // Bu sınıfta yer alan tüm metodlar generic olarak belirlenmiş session nesnesine ait metodlarla iletişime geçer.
    // Ve o metodlara ait tüm veri işlemleri servis bölümünde iş metodu olarak ekstra iş metodlarının yanında implemente edilir.
    public class CoreService<TEntity, TSession> : ICoreService<TEntity, TSession>
        where TEntity : CoreEntity
        where TSession : ICoreSession<TEntity>
    {
        private readonly TSession _session;

        public CoreService(TSession session)
        {
            _session = session;
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression == null
                ? await _session.GetAll()
                : await _session.GetAll(expression);
        }

        public async Task<TEntity> GetById(long id)
        {
            return await _session.GetById(id);
        }

        public async Task Add(TEntity entity)
        {
            await _session.Add(entity);
        }

        public async Task Update(TEntity entity)
        {
            await _session.Update(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await _session.Delete(entity);
        }

        public void BeginTransaction()
        {
            _session.BeginTransaction();
        }

        public async Task CommitTransaction()
        {
            await _session.CommitTransaction();
        }

        public async Task RollbackTransaction()
        {
            await _session.RollbackTransaction();
        }

        public void CloseTransaction()
        {
            _session.CloseTransaction();
        }

        public async Task StartTransactionalOperation(Operation operation, TEntity entity, TEntity? entityFromBody = null)
        {
            if (entityFromBody == null)
                await _session.StartTransactionalOperation(operation, entity);
            else
                await _session.StartTransactionalOperation(operation, entity, entityFromBody);
        }
    }
}