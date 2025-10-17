namespace JaPark.Services.Parking.Application.CarParts.Features.Commands.AddParkingCommand;

internal sealed class AddParkingCommandHandler : ICommandHandler<AddParkingCommand, AddParkingResult>
{
    public Task<Result<AddParkingResult>> Handle(
        AddParkingCommand request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
