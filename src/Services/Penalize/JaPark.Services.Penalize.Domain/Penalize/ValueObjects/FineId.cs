using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Penalize.Domain.Penalize.ValueObjects;

[Prefix("fine")]
public record FineId(string Value) : PrefixedGuidV3(Value);
