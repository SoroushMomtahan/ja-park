using JaPark.Shared.Domain.Events;

namespace JaPark.Services.Parkings.Domain.CarParts.Events;

public sealed class NewSectionAdded(string parkingId) : DomainEvent
{
    public string ParkingId { get; } = parkingId;
}
