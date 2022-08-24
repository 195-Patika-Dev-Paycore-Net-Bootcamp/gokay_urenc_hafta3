using PayCoreClassWork3.WebAPI.Core.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.DataAccess.Abstract
{
    // Container sınıfına ait session interface'i.
    // ICoreSession'dan gerekli ortak özelliklerin kalıtımı alınır.
    // İhtiyaç gelinde yalnızca bu session'a özel olacak metodlar burada belirlenir.
    public interface IContainerSession : ICoreSession<Container>
    {
        Task<IList<Container>> GetByVehicleId(long id); // Araç numarasına göre konteyner listesi getirme.
    }
}