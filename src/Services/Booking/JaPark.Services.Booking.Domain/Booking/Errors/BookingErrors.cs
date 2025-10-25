using JaPark.Services.Booking.Domain.Booking.ValueObjects;
using JaPark.Shared.Domain.Errors;

namespace JaPark.Services.Booking.Domain.Booking.Errors;

public static class BookingErrors
{
    public static readonly Error InvalidPlate = new(
        "bookingErrors.InvalidPlate",
        "پلاک وارد شده صحیح نمی باشد.",
        ErrorType.Validation);

    public static readonly Error InvalidReservationUntilTime = new(
        "bookingErrors.InvalidReservationUntil",
        $"رزرو جا در پارکینگ نمی تواند بیشتر از {Reservation.MaxReservationMinutes} دقیقه یا زمان گذشته باشد.",
        ErrorType.Validation);
}
