using JaPark.Services.Parking.Domain.CarParts.Errors;
using JaPark.Services.Parking.Domain.CarParts.Events;
using JaPark.Services.Parking.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parking.Domain.CarParts.Models;

public sealed class Parking : Aggregate<ParkingId>
{ 
    public ParkingName Name { get; private set; }
    public ParkingAddress Address { get; private set; }
    public ParkingType Type { get; private set; }
    private readonly List<Section> _sections;
    public IReadOnlyList<Section> Sections => [.._sections];
    public Subscription Subscription { get; private set; }
    public SpaceAssignmentPolicy AssignmentPolicy { get; private set; }

    private Parking(
        ParkingName name, 
        ParkingAddress address, 
        ParkingType type)
    {
        Name = name;
        Address = address;
        Type = type;
        AssignmentPolicy = SpaceAssignmentPolicy.Ascending;
        Subscription = Subscription.Default;
        _sections = [];
    }

    public static Result<Parking> Create(
        ParkingName name, 
        ParkingAddress address, 
        ParkingType type)
    {
        return new Parking(name, address, type);
    }

    public Result AddSection(Section section)
    {
        if (_sections.Contains(section))
        {
            return Result.Failure(ParkingErrors.SectionAlreadyAdded);
        }

        if (_sections.Count == Subscription.MaxAcceptableSection)
        {
            return Result.Failure(ParkingErrors.MoreSectionNotAcceptable);
        }

        int totalReservedSpaces = _sections.Sum(x => x.SectionCapacity);
        int remainingSpace = Subscription.MaxAcceptableSpace - totalReservedSpaces;
        int requestedSpace = section.SectionCapacity; 
        if (remainingSpace < requestedSpace)
        {
            return Result.Failure(ParkingErrors.MoreSpaceNotAcceptable(remainingSpace));
        }

        int startSpaceNumber = totalReservedSpaces + 1;
        section.AddSpaces(startSpaceNumber);
        _sections.Add(section);
        AddDomainEvent(new NewSectionAdded(Id.Value, section.Id.Value));
        return Result.Success();
    }

    public Result RemoveSection(Section section)
    {
        if (!_sections.Contains(section))
        {
            return Result.Failure(ParkingErrors.SectionNotFound);
        }
        _sections.Remove(section);
        return Result.Success();
    }

    public Result EditSubscription(Subscription subscription)
    {
        Subscription = subscription;
        return Result.Success();
    }

    public SpaceId TakePlace()
    {
         IEnumerable<Section> sections = AssignmentPolicy.Equals(SpaceAssignmentPolicy.Ascending)
            ? _sections
                .OrderBy(x => x.SectionName.Number)
            : (IEnumerable<Section>)_sections
                .OrderByDescending(x => x.SectionName.Number);
        
        Space space = sections
            .SelectMany(x => x.Spaces)
            .OrderBy(x=>x.Name.Number)
            .First(x => x.Status == SpaceStatus.Available);
        
        space.ChangeStatus(SpaceStatus.Occupied);
        return space.Id;
    }
}
