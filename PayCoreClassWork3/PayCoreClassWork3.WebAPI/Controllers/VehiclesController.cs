using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers;
using PayCoreClassWork3.WebAPI.Dto.Concrete;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : CoreController<Vehicle, VehicleDto, IVehicleService>
    {
        // Vehicle sınıfının servisine ait bağımlılık eklenir. IMapper eklenir.
        public VehiclesController(IVehicleService vehicleService, IMapper mapper) : base(vehicleService, mapper)
        {
        }
    }
}