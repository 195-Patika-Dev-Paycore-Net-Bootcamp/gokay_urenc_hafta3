using FluentValidation;
using PayCoreClassWork3.WebAPI.Dto.Concrete;
using PayCoreClassWork3.WebAPI.Utilities;

namespace PayCoreClassWork3.WebAPI.Validators
{
    // VehicleDto sınıfına ait validasyon işlemleri.
    // FluentValidation kütüphanesinden gelmektedir.
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        public VehicleValidator()
        {
            RuleFor(v => v.VehicleName)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .Length(3, 50).WithMessage(SystemMessage.NAME_LENGTH_ERROR);

            RuleFor(v => v.VehiclePlate)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .Length(3, 30).WithMessage(SystemMessage.PLATE_LENGTH_ERROR);
        }
    }
}