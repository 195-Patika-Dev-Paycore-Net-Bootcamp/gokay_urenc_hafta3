using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : CoreController<Vehicle, IVehicleSession>
    {
        private readonly IVehicleSession _vehicleSession;

        // Vehicle sınıfının session nesnesine ait bağımlılık eklenir.
        public VehiclesController(IVehicleSession vehicleSession) : base(vehicleSession)
        {
            _vehicleSession = vehicleSession;
        }

        // Tüm araçlar listelenir.
        [HttpGet("GetVehicles")]
        public async Task<IList<Vehicle>> GetVehicles()
        {
            return await _vehicleSession.GetAll();
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
            await _vehicleSession.StartTransactionalOperation(Operation.Add, vehicle);
        }

        // Mevcut bir araç güncellenir.
        [HttpPut("UpdateVehicle")]
        public async Task<ActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
        {
            var vehicleToUpdate = GetById(vehicle.Id).Result.Value;

            if (vehicleToUpdate == null)
                return NotFound();

            await _vehicleSession.StartTransactionalOperation(Operation.Update, vehicleToUpdate, vehicle);
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

            await _vehicleSession.StartTransactionalOperation(Operation.Delete, vehicle);
            return Ok();
        }
    }
}