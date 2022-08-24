using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Entity.Concrete.Entities
{
    // Veritabanında "container" tablosuna karşılık gelecek konteyner sınıfı.
    // Sistemin katmanlı ve generic bir yapıda kodlanabilmesi adına ortak bir entity sınıfı olan CoreEntity'den kalıtım alındı.
    public class Container : CoreEntity
    {
        public virtual string ContainerName { get; set; } // Konteyner alanı (Metinsel)
        public virtual double Latitude { get; set; } // Enlem alanı (Ondalıklı)
        public virtual double Longitude { get; set; } // Boylam alanı (Ondalıklı)
        public virtual long VehicleId { get; set; } // Araç numarası alanı (Tam sayı)
    }
}