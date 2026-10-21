using FleetService.Application.DTOs;
using FluentValidation;

namespace FleetService.Application.Validators;

public class CreateBusDtoValidator : AbstractValidator<CreateBusDto>
{
    public CreateBusDtoValidator()
    {
        RuleFor(x => x.Code)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Length(5);

        RuleFor(x => x.Model)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Capacity)
            .GreaterThan(0);
    }
}
