using JaPark.Services.Parking.Domain.CarParts.Errors;

namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record ParkingName
{
    public string Value { get; init; }
    private ParkingName(string value)
    {
        Value = value;
    }
    public static Result<ParkingName> From(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? 
            Result.Failure<ParkingName>(ParkingErrors.NullOrEmptyParkingName) : 
            new ParkingName(value);
    }
    public static implicit operator string(ParkingName value) => value.Value;
    public static implicit operator ParkingName(string value) => From(value).Value;
}
