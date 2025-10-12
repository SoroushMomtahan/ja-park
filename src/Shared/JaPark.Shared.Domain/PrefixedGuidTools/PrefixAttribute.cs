namespace JaPark.Shared.Domain.PrefixedGuidTools;

[AttributeUsage(AttributeTargets.Class)]
public sealed class PrefixAttribute(string prefix) : Attribute
{
    public string Prefix { get; } = prefix;
}
