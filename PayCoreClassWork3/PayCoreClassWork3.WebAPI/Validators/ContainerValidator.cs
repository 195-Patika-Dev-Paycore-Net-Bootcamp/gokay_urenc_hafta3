using FluentValidation;
using PayCoreClassWork3.WebAPI.Dto.Concrete;
using PayCoreClassWork3.WebAPI.Utilities;

namespace PayCoreClassWork3.WebAPI.Validators
{
    // ContainerDto sınıfına ait validasyon işlemleri.
    // FluentValidation kütüphanesinden gelmektedir.
    public class ContainerValidator : AbstractValidator<ContainerDto>
    {
        public ContainerValidator()
        {
            RuleFor(c => c.ContainerName)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .NotNull().WithMessage(SystemMessage.NOT_EMPTY)
                .Length(3, 50).WithMessage(SystemMessage.NAME_LENGTH_ERROR);

            RuleFor(c => c.Latitude)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .NotNull().WithMessage(SystemMessage.NOT_EMPTY);

            RuleFor(c => c.Longitude)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .NotNull().WithMessage(SystemMessage.NOT_EMPTY);

            RuleFor(c => c.VehicleId)
                .NotEmpty().WithMessage(SystemMessage.NOT_EMPTY)
                .NotNull().WithMessage(SystemMessage.NOT_EMPTY);
        }
    }
}