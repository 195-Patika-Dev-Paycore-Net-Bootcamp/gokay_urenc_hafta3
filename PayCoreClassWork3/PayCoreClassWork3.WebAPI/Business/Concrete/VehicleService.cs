using PayCoreClassWork3.WebAPI.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.Business.Concrete;
using PayCoreClassWork3.WebAPI.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Business.Concrete
{
    // Araç sınıfına ait servis sınıfı.
    public class VehicleService : CoreService<Vehicle, IVehicleSession>, IVehicleService
    {
        public VehicleService(IVehicleSession vehicleSession) : base(vehicleSession)
        {
        }
    }
}