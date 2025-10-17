using JaPark.Services.Parking.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parking.Domain.CarParts.Models;

public sealed class Space : Entity<SpaceId>
{
    public SectionId SectionId { get; private set; }
    public SpaceName Name { get; private set; }
    public SpaceStatus Status { get; private set; }

    private Space(SectionId sectionId, SpaceName name)
    {
        SectionId = sectionId;
        Name = name;
        Status = SpaceStatus.Available;
    }

    public static Space Create(SectionId sectionId, SpaceName name)
    {
        return new Space(sectionId, name);
    }

    public void ChangeStatus(SpaceStatus status)
    {
        Status = status;
    }
}
