using JaPark.Services.Parkings.Domain.CarParts.Enums;
using JaPark.Services.Parkings.Domain.CarParts.Errors;
using JaPark.Services.Parkings.Domain.CarParts.Events;
using JaPark.Services.Parkings.Domain.CarParts.ValueObjects;

namespace JaPark.Services.Parkings.Domain.CarParts.Models;

public sealed class Parking : Aggregate<ParkingId>
{ 
    public ParkingName Name { get; private set; }
    public ParkingAddress Address { get; private set; }
    public ParkingType Type { get; private set; }
    private readonly List<ParkingSection> _sections;
    public IReadOnlyList<ParkingSection> Sections => [.._sections];
    public Subscription Subscription { get; private set; }
    public SpaceAssignmentType AssignmentType { get; private set; }

    private Parking(){ }
    private Parking(
        ParkingName name, 
        ParkingAddress address, 
        ParkingType type)
    {
        Name = name;
        Address = address;
        Type = type;
        AssignmentType = SpaceAssignmentType.Asc;
        Subscription = Subscription.Default;
        _sections = [];
    }

    public static Parking Create(
        ParkingName name, 
        ParkingAddress address, 
        ParkingType type)
    {
        return new Parking(name, address, type);
    }

    public Result AddSection(ParkingSection section)
    {
        if (_sections.Contains(section))
        {
            return Result.Failure(ParkingErrors.SectionAlreadyAdded);
        }

        if (_sections.Count == Subscription.MaxAcceptableSection)
        {
            return Result.Failure(ParkingErrors.MoreSectionNotAcceptable);
        }

        int totalTakingCapacity = _sections.Sum(x => x.Capacity);
        int remainingCapacity = Subscription.MaxAcceptableSpace - totalTakingCapacity;
        int requestedSpace = section.Capacity; 
        if (remainingCapacity < requestedSpace)
        {
            return Result.Failure(ParkingErrors.MoreSpaceNotAcceptable(remainingCapacity));
        }
        
        _sections.Add(section);
        AddDomainEvent(new NewSectionAdded(Id.Value));
        return Result.Success();
    }

    public Result RemoveSection(ParkingSection parkingSection)
    {
        if (!_sections.Contains(parkingSection))
        {
            return Result.Failure(ParkingErrors.SectionNotFound);
        }
        _sections.Remove(parkingSection);
        return Result.Success();
    }

    public Result EditSubscription(Subscription subscription)
    {
        Subscription = subscription;
        return Result.Success();
    }
}
