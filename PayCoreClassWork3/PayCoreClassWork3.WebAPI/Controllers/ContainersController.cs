using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Dto.Concrete;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;
using PayCoreClassWork3.WebAPI.Utilities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : CoreController<Container, ContainerDto, IContainerService>
    {
        private readonly IContainerService _containerService;

        // Container sınıfının servisine ait bağımlılık eklenir. IMapper eklenir.
        public ContainersController(IContainerService containerService, IMapper mapper) : base(containerService, mapper)
        {
            _containerService = containerService;
        }

        // Araç numarasına göre konteyner listesi listelenir.
        [HttpGet("GetContainersByVehicleId/{vehicleId}")]
        public async Task<ActionResult<List<Container>>> GetContainersByVehicleId(long? vehicleId)
        {
            if (vehicleId == null)
                return BadRequest(SystemMessage.ID_NULL);

            return Ok(await _containerService.GetByVehicleId((long)vehicleId));
        }

        // Belirlenen araç numarası üzerinden konteyner listesinde arama yapılır.
        // Eğer bu araç numarasına ait toplam konteyner sayısı 1 ise veya 1'den az ise, "Geçersiz İstek" hatası döndürülür.
        // Eğer küme başına belirlenen maksimum eleman sayısı en az 1 değilse, "Geçersiz İstek" hatası döndürülür.
        // Eğer bulunan konteynerlerin sayısı küme başına belirlenen maksimum eleman sayısından küçükse, "Geçersiz İstek" hatası döndürülür.
        // Tüm validasyonlardan geçilmesi durumunda ise konteynerler kümelenmiş bir biçimde döndürülür.
        [HttpGet("{vehicleId}/{maxElementsPerCluster}")]
        public async Task<ActionResult<List<List<Container>>>> GetClusteredContainers(long? vehicleId, int maxElementsPerCluster)
        {
            var containers = await _containerService.GetAll(c => c.VehicleId == vehicleId);

            if (containers.Count <= 1)
                return BadRequest(SystemMessage.CONTAINER_COUNT_ERROR);
            if (maxElementsPerCluster <= 0)
                return BadRequest(SystemMessage.CHUNK_ERROR);
            if (containers.Count < maxElementsPerCluster)
                return BadRequest(SystemMessage.LESS_COUNT_ERROR);

            var clusteredContainers = _containerService.ClusterContainers(containers, maxElementsPerCluster);
            return Ok(clusteredContainers);
        }
    }
}