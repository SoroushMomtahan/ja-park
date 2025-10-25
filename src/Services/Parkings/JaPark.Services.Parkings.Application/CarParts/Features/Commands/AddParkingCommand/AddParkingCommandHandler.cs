using JaPark.Services.Parkings.Application.Abstractions.Data;
using JaPark.Services.Parkings.Domain.CarParts.Repository;
using JaPark.Services.Parkings.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parkings.Application.CarParts.Features.Commands.AddParkingCommand;

internal sealed class AddParkingCommandHandler(
    IParkingRepository parkingRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<AddParkingCommand, AddParkingResult>
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
        
        var parking = Parkings.Domain.CarParts.Models.Parking.Create(
            parkingNameOrError.Value, address, request.Type);
        
        await parkingRepository.AddParkingAsync(parking, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AddParkingResult(parking.Id.Value);
    }
}
