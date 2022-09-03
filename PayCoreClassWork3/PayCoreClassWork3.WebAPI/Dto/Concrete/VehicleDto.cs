using PayCoreClassWork3.WebAPI.Core.Dto.Abstract;

namespace PayCoreClassWork3.WebAPI.Dto.Concrete
{
    // Vehicle sınıfına ait veri transfer sınıfı.
    public class VehicleDto : ICoreDto
    {
        public string VehicleName { get; set; } // Araç adı alanı (Metinsel)
        public string VehiclePlate { get; set; } // Araç plakası alanı (Metinsel)
    }
}