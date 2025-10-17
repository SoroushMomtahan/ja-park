using JaPark.Services.Parking.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parking.Domain.CarParts.Models;

public sealed class Section : Entity<SectionId>
{
    public ParkingId ParkingId { get; private set; }
    public SectionName SectionName { get; private set; }
    private readonly List<Space> _spaces = [];
    public IReadOnlyList<Space> Spaces => [.._spaces];
    public SectionCapacity SectionCapacity { get; private set; }

    public Section(
        ParkingId parkingId,
        SectionName sectionName, 
        SectionCapacity sectionCapacity)
    {
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
            var space = Space.Create(Id, spaceName);
            _spaces.Add(space);
        }
    }
}
