using PayCoreClassWork3.WebAPI.Core.Business.Abstract;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Business.Abstract
{
    // Vehicle sınıfına ait servis interface'i.
    // ICoreService'den gerekli ortak özelliklerin kalıtımı alınır.
    // İhtiyaç halinde yalnızca bu servis'a özel olacak metodlar burada belirlenir.
    public interface IVehicleService : ICoreService<Vehicle, IVehicleSession>
    {
    }
}