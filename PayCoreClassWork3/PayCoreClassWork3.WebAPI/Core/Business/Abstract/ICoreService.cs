using PayCoreClassWork3.WebAPI.Core.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.Business.Abstract
{
    // Tüm diğer servis interface'leri buradan kalıtım alır.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmalıdır.
    // TSession, belirlenen TEntity nesnesine ait uygun session nesnesi olmalıdr. Aksi halde hata verir.
    public interface ICoreService<TEntity, TSession> : IService<TEntity>
        where TEntity : CoreEntity
        where TSession : ICoreSession<TEntity>
    {
    }
}