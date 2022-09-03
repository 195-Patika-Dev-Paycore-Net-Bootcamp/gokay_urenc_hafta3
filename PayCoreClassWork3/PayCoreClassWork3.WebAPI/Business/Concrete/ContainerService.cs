using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.Business.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Business.Concrete
{
    // Konteyner sınıfına ait servis sınıfı.
    public class ContainerService : CoreService<Container, IContainerSession>, IContainerService
    {
        private readonly IContainerSession _containerSession;

        public ContainerService(IContainerSession containerSession) : base(containerSession)
        {
            _containerSession = containerSession;
        }

        // Araç numarasına göre konteyner listesi getirme.
        public async Task<List<Container>> GetByVehicleId(long id)
        {
            return await _containerSession.GetAll(c => c.VehicleId == id);
        }

        // Bir konteyner listesinin elemanlarını belirlenen maksimum değerde olacak şekilde kümelere ayırma.
        public IEnumerable<List<Container>> ClusterContainers(List<Container> containers, int maxElementsPerCluster)
        {
            for (int i = 0; i < containers.Count; i += maxElementsPerCluster)
            {
                yield return containers.GetRange(i, Math.Min(maxElementsPerCluster, containers.Count - i));
            }
        }
    }
}