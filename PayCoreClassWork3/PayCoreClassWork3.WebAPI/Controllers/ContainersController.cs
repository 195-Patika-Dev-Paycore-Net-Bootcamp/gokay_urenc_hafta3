using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : CoreController<Container, IContainerService>
    {
        private readonly IContainerService _containerService;

        // Container sınıfının servisine ait bağımlılık eklenir.
        public ContainersController(IContainerService containerService) : base(containerService)
        {
            _containerService = containerService;
        }

        // Tüm konteynerler listelenir.
        [HttpGet("GetContainers")]
        public async Task<IList<Container>> GetContainers()
        {
            return await _containerService.GetAll();
        }

        // Id'ye göre konteyner araması yapılır.
        [HttpGet("GetContainer/{id}")]
        public async Task<ActionResult<Container>> GetContainer(long? id)
        {
            return await GetById(id);
        }

        // Araç numarasına göre konteyner listesi listelenir.
        [HttpGet("GetContainersByVehicleId/{vehicleId}")]
        public async Task<ActionResult<List<Container>>> GetContainersByVehicleId(long? vehicleId)
        {
            if (vehicleId == null)
                return BadRequest();

            return Ok(await _containerService.GetByVehicleId((long)vehicleId));
        }

        // Belirlenen araç numarası üzerinden konteyner listesinde arama yapılır.
        // Eğer bu araç numarasına ait toplam konteyner sayısı 1 ise veya 1'den az ise, "Geçersiz İstek" hatası döndürülür.
        // Eğer küme başına belirlenen maksimum eleman sayısı en az 1 değilse, "Geçersiz İstek" hatası döndürülür.
        // Eğer bulunan konteynerlerin sayısı küme başına belirlenen maksimum eleman sayısından küçükse, "Geçersiz İstek" hatası döndürülür.
        // Tüm validasyonlardan geçilmesi durumunda ise konteynerler kümelenmiş bir biçimde döndürülür.
        [HttpGet("GetClusteredContainers/{vehicleId}/{maxElementsPerCluster}")]
        public async Task<ActionResult<List<List<Container>>>> GetClusteredContainers(long? vehicleId, int maxElementsPerCluster)
        {
            var containers = await _containerService.GetAll(c => c.VehicleId == vehicleId);

            if (containers.Count <= 1)
                return BadRequest("Container count must be at least 2. Otherwise containers can't be clustered.");
            if (maxElementsPerCluster <= 0)
                return BadRequest("Max element count in each cluster must be at least 1.");
            if (containers.Count < maxElementsPerCluster)
                return BadRequest("To cluster containers, max element count must be less than container count.");

            var clusteredContainers = _containerService.ClusterContainers(containers, maxElementsPerCluster);
            return Ok(clusteredContainers);
        }

        // Yeni bir konteyner eklenir.
        [HttpPost("AddContainer")]
        public async Task AddContainer([FromBody] Container container)
        {
            await _containerService.StartTransactionalOperation(Operation.Add, container);
        }

        // Mevcut bir konteyner güncellenir.
        [HttpPut("UpdateContainer")]
        public async Task<ActionResult> UpdateContainer([FromBody] Container container)
        {
            var containerToUpdate = GetById(container.Id).Result.Value;

            if (containerToUpdate == null)
                return NotFound();

            await _containerService.StartTransactionalOperation(Operation.Update, containerToUpdate, container);
            return Ok();
        }

        // Id'si belirlenen bir konteyner silinir.
        [HttpDelete("DeleteContainer/{id}")]
        public async Task<ActionResult> DeleteContainer(long? id)
        {
            var container = GetById(id).Result.Value;

            if (container == null)
                return NotFound();

            await _containerService.StartTransactionalOperation(Operation.Delete, container);
            return Ok();
        }
    }
}