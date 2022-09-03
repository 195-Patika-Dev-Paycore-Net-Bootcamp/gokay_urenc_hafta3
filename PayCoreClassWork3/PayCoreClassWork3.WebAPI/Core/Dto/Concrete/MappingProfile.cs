using AutoMapper;
using PayCoreClassWork3.WebAPI.Dto.Concrete;
using PayCoreClassWork3.WebAPI.Entity.Concrete.Entities;

namespace PayCoreClassWork3.WebAPI.Core.Dto.Concrete
{
    // Cast işlemlerinin otomatik olarak gerçekleştirilebilmesi için gerekli sınıftır.
    // AutoMapper kütüphanesinden gelmektedir.
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<ContainerDto, Container>().ReverseMap();
        }
    }
}