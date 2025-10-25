using JaPark.Services.Parkings.Domain.CarParts.Errors;

namespace JaPark.Services.Parkings.Application.CarParts.Features.Commands.AddParkingCommand;

internal sealed class AddParkingCommandValidation : AbstractValidator<AddParkingCommand>
{
    public AddParkingCommandValidation()
    {
        RuleFor(x => x.ParkingName)
            .NotEmpty()
            .WithMessage(ParkingErrors.NullOrEmptyParkingName.Description);
    }
}
