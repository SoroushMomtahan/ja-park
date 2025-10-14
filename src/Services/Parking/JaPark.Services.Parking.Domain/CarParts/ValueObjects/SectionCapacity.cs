namespace JaPark.Services.Parking.Domain.CarParts.ValueObjects;

public record SectionCapacity(int Value)
{
    public static implicit operator int(SectionCapacity sectionCapacity) => sectionCapacity.Value;
    public static implicit operator SectionCapacity(int value) => new(value);
}
