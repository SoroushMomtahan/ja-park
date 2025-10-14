using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

[Prefix("section")]
public record SectionId(string Value) : PrefixedGuidV3(Value);
