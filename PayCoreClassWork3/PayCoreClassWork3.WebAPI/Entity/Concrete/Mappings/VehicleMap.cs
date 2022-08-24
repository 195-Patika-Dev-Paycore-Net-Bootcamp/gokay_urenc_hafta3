using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Entity.Concrete.Mappings
{
    // Vehicle sınıfının veritabanında yer alan "vehicle" tablosuyla olan eşleşme konfigürasyonunun yapıldığı sınıf.
    // Konfigürasyonun sağlanabilmesi için NHibernate kütüphanesine ait ClassMapping sınıfından kalıtım alınır.
    // Generic operatürünün içinde ise eşleştirme için kullanılacak sınıfın adı yazılır.
    public class VehicleMap : ClassMapping<Vehicle>
    {
        public VehicleMap()
        {
            // Hangi tabloya ait olduğu belirlenir.
            Table("vehicles");

            // Id özelliği taşıyan kolon ve o kolona ait özellikler belirlenir.
            Id(v => v.Id, i =>
            {
                i.Column("id");
                i.Type(NHibernateUtil.Int64);
                i.UnsavedValue(0);
                i.Generator(Generators.Increment);
            });

            // Araç adı alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(v => v.VehicleName, n =>
            {
                n.Column("vehiclename");
                n.Type(NHibernateUtil.String);
                n.Length(50);
                n.NotNullable(false);
            });

            // Araç plakası alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(v => v.VehiclePlate, p =>
            {
                p.Column("vehicleplate");
                p.Type(NHibernateUtil.String);
                p.Length(14);
                p.NotNullable(false);
            });
        }
    }
}