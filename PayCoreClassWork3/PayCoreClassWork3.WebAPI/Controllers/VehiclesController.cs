using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : CoreController<Vehicle, IVehicleService>
    {
        private readonly IVehicleService _vehicleService;

        // Vehicle sınıfının servisine ait bağımlılık eklenir.
        public VehiclesController(IVehicleService vehicleService) : base(vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // Tüm araçlar listelenir.
        [HttpGet("GetVehicles")]
        public async Task<IList<Vehicle>> GetVehicles()
        {
            return await _vehicleService.GetAll();
        }

        // Id'ye göre araç araması yapılır.
        [HttpGet("GetVehicle/{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicle(long? id)
        {
            return await GetById(id);
        }

        // Yeni bir araç eklenir.
        [HttpPost("AddVehicle")]
        public async Task AddVehicle([FromBody] Vehicle vehicle)
        {
            await _vehicleService.StartTransactionalOperation(Operation.Add, vehicle);
        }

        // Mevcut bir araç güncellenir.
        [HttpPut("UpdateVehicle")]
        public async Task<ActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            var vehicleToUpdate = GetById(vehicle.Id).Result.Value;

            if (vehicleToUpdate == null)
                return NotFound();

            await _vehicleService.StartTransactionalOperation(Operation.Update, vehicleToUpdate, vehicle);
            return Ok();
        }

        // Id'si belirlenen bir araç silinir.
        // Öncesinde ise bu araca ait konteynerler silinir.
        // SetTransactionalOperation metodu, VehicleSession sınıfında bu işleme göre implemente edilmiştir.
        [HttpDelete("DeleteVehicle/{id}")]
        public async Task<ActionResult> DeleteVehicle(long? id)
        {
            var vehicle = GetById(id).Result.Value;

            if (vehicle == null)
                return NotFound();

            await _vehicleService.StartTransactionalOperation(Operation.Delete, vehicle);
            return Ok();
        }
    }
}