using PayCoreClassWork3.WebAPI.Core.Business.Abstract;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Business.Abstract
{
    // Container sınıfına ait servis interface'i.
    // ICoreService'den gerekli ortak özelliklerin kalıtımı alınır.
    // İhtiyaç halinde yalnızca bu servis'a özel olacak metodlar burada belirlenir.
    public interface IContainerService : ICoreService<Container, IContainerSession>
    {
        Task<List<Container>> GetByVehicleId(long id); // Araç numarasına göre konteyner listesi getirme.
        IEnumerable<List<Container>> ClusterContainers(List<Container> containers, int maxElementsPerCluster); // Bir konteyner listesinin elemanlarını belirlenen maksimum değerde olacak şekilde kümelere ayırma.
    }
}