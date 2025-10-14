using JaPark.Services.Parking.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parking.Domain.CarParts.Models;

public sealed class Space : Entity
{
    public SpaceId Id { get; private set; }
    public SectionId SectionId { get; private set; }
    public SpaceName Name { get; private set; }
    public SpaceStatus Status { get; private set; }

    private Space(SpaceId id, SectionId sectionId, SpaceName name)
    {
        Id = id;
        SectionId = sectionId;
        Name = name;
        Status = SpaceStatus.Available;
    }

    public static Space Create(SpaceId id, SectionId sectionId, SpaceName name)
    {
        return new Space(id, sectionId, name);
    }

    public void ChangeStatus(SpaceStatus status)
    {
        Status = status;
    }
}
