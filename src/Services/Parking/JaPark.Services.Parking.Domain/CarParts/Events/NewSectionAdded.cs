using JaPark.Shared.Domain.Events;

namespace JaPark.Services.Parking.Domain.CarParts.Events;

public sealed class NewSectionAdded(string parkingId, string sectionId) : DomainEvent
{
    public string ParkingId { get; } = parkingId;
    public string SectionId { get; } = sectionId;
}
