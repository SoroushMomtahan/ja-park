namespace JaPark.Services.Booking.Domain.Booking.ValueObjects;

public record Reservation
{
    public const int MaxReservationMinutes = 115;
    public const int MaxPendingMinutesAfterReservationEnd = 5;
    public DateTime ReserveUntil { get; init; }
    public DateTime ReservationExpireIn { get; init; }
    
    private Reservation(
        DateTime reserveUntil, 
        DateTime reservationExpireIn) => 
        (ReserveUntil, ReservationExpireIn) = (reserveUntil, reservationExpireIn);

    public static Result<Reservation> From(DateTime reserveUntil)
    {
        if (reserveUntil <= DateTime.Now || 
            reserveUntil > DateTime.Now.AddMinutes(MaxReservationMinutes))
        {
            return Result.Failure<Reservation>(BookingErrors.InvalidReservationUntilTime);
        }

        DateTime reservationExpireIn = reserveUntil.AddMinutes(MaxPendingMinutesAfterReservationEnd);
        return new Reservation(reserveUntil, reservationExpireIn);
    }
}
public record OptionalReservation
{ 
    private Option<Reservation> Optional { get; init; }

    private OptionalReservation(Option<Reservation> reservation) => Optional = reservation;
    
    public static readonly OptionalReservation WithoutReservation = new(Option<Reservation>.None);
    public static OptionalReservation WithReservation(
        Reservation reservation) => new(Option<Reservation>.Some(reservation)); 

    public static Result<OptionalReservation> From(DateTime? reserveUntil)
    {
        if (!reserveUntil.HasValue)
        {
            return WithoutReservation;
        }

        Result<Reservation> reservationOrError = Reservation.From(reserveUntil.Value);
        return reservationOrError.IsFailure ? 
            Result.Failure<OptionalReservation>(reservationOrError.Error) : 
            WithReservation(reservationOrError.Value);
    }

    public bool TryGetReservation(out Reservation? reservation)
    {
        return Optional.TryGetValue(out reservation);
    }

}
