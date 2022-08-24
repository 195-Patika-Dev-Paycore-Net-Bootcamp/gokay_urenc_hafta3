using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Entity.Concrete.Mappings
{
    // Container sınıfının veritabanında yer alan "container" tablosuyla olan eşleşme konfigürasyonunun yapıldığı sınıf.
    // Konfigürasyonun sağlanabilmesi için NHibernate kütüphanesine ait ClassMapping sınıfından kalıtım alınır.
    // Generic operatürünün içinde ise eşleştirme için kullanılacak sınıfın adı yazılır.
    public class ContainerMap : ClassMapping<Container>
    {
        public ContainerMap()
        {
            // Hangi tabloya ait olduğu belirlenir.
            Table("containers");

            // Id özelliği taşıyan kolon ve o kolona ait özellikler belirlenir.
            Id(c => c.Id, i =>
            {
                i.Column("id");
                i.Type(NHibernateUtil.Int64);
                i.UnsavedValue(0);
                i.Generator(Generators.Increment);
            });

            // Konteyner adı alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(c => c.ContainerName, c =>
            {
                c.Column("containername");
                c.Type(NHibernateUtil.String);
                c.Length(50);
                c.NotNullable(false);
            });

            // Enlem alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(c => c.Latitude, l =>
            {
                l.Column("latitude");
                l.Type(NHibernateUtil.Double);
                l.Precision(10);
                l.Scale(6);
                l.NotNullable(false);
            });

            // Boylam alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(c => c.Longitude, l =>
            {
                l.Column("longitude");
                l.Type(NHibernateUtil.Double);
                l.Precision(10);
                l.Scale(6);
                l.NotNullable(false);
            });

            // Araç numarası alanına ait veritabanındaki özelliklerin eşleştirmesi yapılır.
            Property(c => c.VehicleId, i =>
            {
                i.Column("vehicleid");
                i.Type(NHibernateUtil.Int64);
                i.NotNullable(false);
            });
        }
    }
}