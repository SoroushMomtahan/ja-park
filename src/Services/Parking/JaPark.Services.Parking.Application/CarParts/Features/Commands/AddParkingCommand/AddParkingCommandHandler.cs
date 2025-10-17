using JaPark.Services.Parking.Domain.CarParts.Repository;
using JaPark.Services.Parking.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parking.Application.CarParts.Features.Commands.AddParkingCommand;

internal sealed class AddParkingCommandHandler(
    IParkingRepository parkingRepository) : ICommandHandler<AddParkingCommand, AddParkingResult>
{
    public async Task<Result<AddParkingResult>> Handle(
        AddParkingCommand request, 
        CancellationToken cancellationToken)
    {
        Result<ParkingName> parkingNameOrError = ParkingName.From(request.ParkingName);
        if (parkingNameOrError.IsFailure)
        {
            return Result.Failure<AddParkingResult>(parkingNameOrError.Error);
        }
        
        var address = ParkingAddress.From(
            request.ParkingMapAddress, 
            request.ParkingTextAddress);
        
        var parking = Domain.CarParts.Models.Parking.Create(
            parkingNameOrError.Value, address, request.Type);
        
        await parkingRepository.AddParkingAsync(parking, cancellationToken);
        
        return new AddParkingResult(parking.Id.Value);
    }
}
