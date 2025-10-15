using JaPark.Services.Booking.Domain.Booking.ValueObjects;

namespace JaPark.Services.Booking.Domain.Booking.Models;

public sealed class Booking : Aggregate
{
    public BookingId Id { get; private set; }
    public SpaceId SpaceId { get; private set; }
    public PlateNumber PlateNumber { get; private set; }
    public DateTime LoginAt { get; private set; }
    public DateTime LogoutAt { get; private set; }


    private Booking(BookingId id, SpaceId spaceId, PlateNumber plateNumber)
    {
        Id = id;
        SpaceId = spaceId;
        PlateNumber = plateNumber; 
    }
    public static Result<Booking> Login(
        BookingId id, 
        SpaceId spaceId, 
        PlateNumber plateNumber)
    {
        var booking = new Booking(id, spaceId, plateNumber)
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
