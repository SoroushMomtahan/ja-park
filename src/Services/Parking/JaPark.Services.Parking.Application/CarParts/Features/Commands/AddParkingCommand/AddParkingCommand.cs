using JaPark.Services.Parking.Domain.CarParts.Enums;

namespace JaPark.Services.Parking.Application.CarParts.Features.Commands.AddParkingCommand;

public sealed record AddParkingCommand(
    string ParkingName,
    string ParkingMapAddress,
    string ParkingTextAddress,
    ParkingType Type) : ICommand<AddParkingResult>;
