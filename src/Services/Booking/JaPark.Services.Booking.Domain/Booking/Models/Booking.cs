using JaPark.Services.Booking.Domain.Booking.ValueObjects;

namespace JaPark.Services.Booking.Domain.Booking.Models;

public sealed class Booking : Aggregate<BookingId>
{ 
    public SpaceId SpaceId { get; private set; }
    public PlateNumber PlateNumber { get; private set; }
    public DateTime LoginAt { get; private set; }
    public DateTime LogoutAt { get; private set; }


    private Booking(SpaceId spaceId, PlateNumber plateNumber)
    {
        SpaceId = spaceId;
        PlateNumber = plateNumber; 
    }
    public static Result<Booking> Login(
        SpaceId spaceId, 
        PlateNumber plateNumber)
    {
        var booking = new Booking(spaceId, plateNumber)
        {
            LoginAt = DateTime.Now
        };
        return Result.Success(booking);
    }

    public void Logout(DateTime logoutAt)
    {
        LogoutAt = logoutAt;
    }
}
