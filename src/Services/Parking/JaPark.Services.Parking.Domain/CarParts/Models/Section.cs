using JaPark.Services.Parking.Domain.CarParts.ValueObjects;
using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parking.Domain.CarParts.Models;

public sealed class Section : Entity
{
    public SectionId Id { get; private set; }
    public ParkingId ParkingId { get; private set; }
    public SectionName SectionName { get; private set; }
    private readonly List<Space> _spaces = [];
    public IReadOnlyList<Space> Spaces => [.._spaces];
    public SectionCapacity SectionCapacity { get; private set; }

    public Section(
        SectionId id, 
        ParkingId parkingId,
        SectionName sectionName, 
        SectionCapacity sectionCapacity)
    {
        Id = id;
        ParkingId = parkingId;
        SectionCapacity =  sectionCapacity;
        SectionName = sectionName;
    }

    public void AddSpaces(int from)
    {
        for (int startSpaceNumber = from; startSpaceNumber <= SectionCapacity.Value; startSpaceNumber++)
        {
            var spaceName = SpaceName.From(
                $"{SectionName.Prefix}{SectionName.Number}", 
                startSpaceNumber);
            SpaceId spaceId = PrefixedGuidV3.New<SpaceId>();
            var space = Space.Create(spaceId, Id, spaceName);
            _spaces.Add(space);
        }
    }
}
