using PayCoreClassWork3.WebAPI.Core.Dto.Abstract;

namespace PayCoreClassWork3.WebAPI.Dto.Concrete
{
    // Container sınıfına ait veri transfer sınıfı.
    public class ContainerDto : ICoreDto
    {
        public string ContainerName { get; set; } // Konteyner alanı (Metinsel)
        public double Latitude { get; set; } // Enlem alanı (Ondalıklı)
        public double Longitude { get; set; } // Boylam alanı (Ondalıklı)
        public long VehicleId { get; set; } // Araç numarası alanı (Tam sayı)
    }
}