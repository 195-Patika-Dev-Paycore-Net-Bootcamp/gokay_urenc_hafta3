using PayCoreClassWork3.WebAPI.Core.Entity.Abstract;

namespace PayCoreClassWork3.WebAPI.Core.Entity.Concrete
{
    // Veritabanındaki tabloları temsil edecek olan sınıflar buradan kalıtım alır.
    // Tüm diğer sınıflarda yer alacak ortak özelliklerin bulunabileceği sınıftır.
    // Generic olan ICoreEntity interface'ini implemente ederek Id kolonuna generic operatör aracılığıyla tip belirlenir.
    public class CoreEntity : ICoreEntity<long>
    {
        public virtual long Id { get; set; } // İmplementasyon yoluyla elde edilen Id alanı (Int64, long, bigint)
    }
}