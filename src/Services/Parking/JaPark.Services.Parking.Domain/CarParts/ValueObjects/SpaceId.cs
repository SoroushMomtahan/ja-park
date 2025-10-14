using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

[Prefix("space")]
public record SpaceId(string Value) : PrefixedGuidV3(Value);
