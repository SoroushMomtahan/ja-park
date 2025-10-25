using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parkings.Domain.CarParts.ValueObjects;

[Prefix("parking")]
public record ParkingId(string Value) : PrefixedGuidV3(Value)
{
    public static implicit operator ParkingId(string input) => new(input);
}
