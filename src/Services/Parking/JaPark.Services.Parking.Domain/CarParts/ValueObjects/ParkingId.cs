using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

[Prefix("parking")]
public record ParkingId(string Value) : PrefixedGuidV3(Value);
