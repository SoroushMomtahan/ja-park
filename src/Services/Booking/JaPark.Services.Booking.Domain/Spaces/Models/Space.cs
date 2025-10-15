using JaPark.Services.Booking.Domain.Spaces.ValueObjects;

namespace JaPark.Services.Booking.Domain.Spaces.Models;

public sealed class Space : Aggregate
{
    public SpaceId Id { get; private set; }
    public ParkingId ParkingId { get; private set; }
    public SpaceName SpaceName { get; private set; }
    public SpaceStatus SpaceStatus { get; private set; }

    private Space(
        SpaceId id,
        ParkingId parkingId,
        SpaceName spaceName,
        SpaceStatus spaceStatus)
    {
        Id = id;
        ParkingId = parkingId;
        SpaceName = spaceName;
        SpaceStatus = spaceStatus;
    }

    public static Space Create(
        SpaceId id,
        ParkingId parkingId,
        SpaceName spaceName,
        SpaceStatus spaceStatus)
    {
        return new Space(id, parkingId, spaceName, spaceStatus);
    }
}
