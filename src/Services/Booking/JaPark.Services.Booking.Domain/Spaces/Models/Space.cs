using JaPark.Services.Booking.Domain.Spaces.ValueObjects;

namespace JaPark.Services.Booking.Domain.Spaces.Models;

public sealed class Space : Aggregate<SpaceId>
{ 
    public ParkingId ParkingId { get; private set; }
    public SpaceName SpaceName { get; private set; }
    public SpaceStatus SpaceStatus { get; private set; }

    private Space(
        ParkingId parkingId,
        SpaceName spaceName,
        SpaceStatus spaceStatus)
    {
        ParkingId = parkingId;
        SpaceName = spaceName;
        SpaceStatus = spaceStatus;
    }

    public static Space Create(
        ParkingId parkingId,
        SpaceName spaceName,
        SpaceStatus spaceStatus)
    {
        return new Space(parkingId, spaceName, spaceStatus);
    }
}
