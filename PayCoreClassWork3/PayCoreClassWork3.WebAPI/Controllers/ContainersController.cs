using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersController : CoreController<Container, IContainerSession>
    {
        private readonly IContainerSession _containerSession;

        // Container sınıfının session nesnesine ait bağımlılıklar eklenir.
        public ContainersController(IContainerSession containerSession) : base(containerSession)
        {
            _containerSession = containerSession;
        }

        // Tüm konteynerler listelenir.
        [HttpGet("GetContainers")]
        public async Task<IList<Container>> GetContainers()
        {
            return await _containerSession.GetAll();
        }

        // Id'ye göre konteyner araması yapılır.
        [HttpGet("GetContainer/{id}")]
        public async Task<ActionResult<Container>> GetContainer(long? id)
        {
            return await GetById(id);
        }

        // Araç numarasına göre konteyner listesi listelenir.
        [HttpGet("GetContainersByVehicleId/{vehicleId}")]
        public async Task<ActionResult<IList<Container>>> GetContainersByVehicleId(long? vehicleId)
        {
            if (vehicleId == null)
                return BadRequest();

            return Ok(await _containerSession.GetByVehicleId((long)vehicleId));
        }

        // Araç numarası belirlenen konteynerlerin belirlenen sayıda kümelere bölünerek listelenmesini sağlar.
        // Belirlenen araç numarası üzerinden konteyner listesinde arama yapılır.
        // Eğer bu araç numarasına ait toplam konteyner sayısı 1 ise veya 1'den az ise, "Geçersiz İstek" hatası döndürülür.
        // Eğer belirlenen küme sayısı en az 1 değilse, "Geçersiz İstek" hatası döndürülür.
        // Eğer bulunan konteynerlerin sayısı küme sayısından küçükse, "Geçersiz İstek" hatası döndürülür.
        // Eğer bulunan konteynerlerin sayısı belirlenen küme sayısının katı değilse yani eşit bölünemiyorsa, "Geçersiz İstek" hatası döndürülür.
        // Tüm validasyonlardan geçilmesi durumunda ise konteynerler kümelenmiş bir biçimde döndürülür.
        [HttpGet("GetClusteredContainers/{vehicleId}/{clusterCount}")]
        public async Task<ActionResult<List<IList<Container>>>> GetClusteredContainers(long? vehicleId, int clusterCount)
        {
            var containers = await _containerSession.GetAll(c => c.VehicleId == vehicleId);

            if (containers.Count <= 1)
                return BadRequest("Container count must be at least 2. Otherwise containers can't be clustered.");
            if (clusterCount <= 0)
                return BadRequest("Cluster count must be at least 1.");
            if (containers.Count < clusterCount)
                return BadRequest("To cluster containers, cluster count must be less than container count.");
            if (containers.Count % clusterCount != 0)
                return BadRequest("Containers must be divided equally into clusters.");
            
            var count = containers.Count / clusterCount;
            var clusterList = new List<IList<Container>>();

            for (int i = 0; i < clusterCount; i++)
            {
                clusterList.Add(new List<Container>());

                for (int j = 0; j < count; j++)
                {
                    clusterList[i].Add(containers[j]);
                }
            }

            return clusterList;
        }

        // Yeni bir konteyner eklenir.
        [HttpPost("AddContainer")]
        public async Task AddContainer([FromBody] Container container)
        {
            await _containerSession.StartTransactionalOperation(Operation.Add, container);
        }

        // Mevcut bir konteyner güncellenir.
        [HttpPut("UpdateContainer")]
        public async Task<ActionResult> UpdateContainer([FromBody] Container container)
        {
            var containerToUpdate = GetById(container.Id).Result.Value;

            if (containerToUpdate == null)
                return NotFound();

            await _containerSession.StartTransactionalOperation(Operation.Update, containerToUpdate, container);
            return Ok();
        }

        // Id'si belirlenen bir konteyner silinir.
        [HttpDelete("DeleteContainer/{id}")]
        public async Task<ActionResult> DeleteContainer(long? id)
        {
            var container = GetById(id).Result.Value;

            if (container == null)
                return NotFound();

            await _containerSession.StartTransactionalOperation(Operation.Delete, container);
            return Ok();
        }
    }
}