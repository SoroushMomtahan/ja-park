namespace JaPark.Services.Parking.Application.CarParts.Features.Commands.AddParkingCommand;

public sealed record AddParkingCommand(
    string ParkingName,
    string ParkingAddress,
    string Type) : ICommand<AddParkingResult>;
