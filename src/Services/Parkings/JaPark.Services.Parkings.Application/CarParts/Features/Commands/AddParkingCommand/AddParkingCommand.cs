using JaPark.Services.Parkings.Domain.CarParts.Enums;

namespace JaPark.Services.Parkings.Application.CarParts.Features.Commands.AddParkingCommand;

public sealed record AddParkingCommand(
    string ParkingName,
    string ParkingMapAddress,
    string ParkingTextAddress,
    ParkingType Type) : ICommand<AddParkingResult>;
