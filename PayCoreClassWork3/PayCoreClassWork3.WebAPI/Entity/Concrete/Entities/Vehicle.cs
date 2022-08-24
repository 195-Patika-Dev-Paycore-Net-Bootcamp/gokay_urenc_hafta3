using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Entity.Concrete.Entities
{
    // Veritabanında "vehicle" tablosuna karşılık gelecek araç sınıfı.
    // Sistemin katmanlı ve generic bir yapıda kodlanabilmesi adına ortak bir entity sınıfı olan CoreEntity'den kalıtım alındı.
    public class Vehicle : CoreEntity
    {
        public virtual string VehicleName { get; set; } // Araç adı alanı (Metinsel)
        public virtual string VehiclePlate { get; set; } // Araç plakası alanı (Metinsel)
    }
}