using JaPark.Shared.Domain.Errors;

namespace JaPark.Services.Booking.Domain.Booking.Errors;

public static class bookingErros
{
    public static readonly Error InvalidPlate = new(
        "bookingErros.InvalidPlate",
        "پلاک وارد شده صحیح نمی باشد.",
        ErrorType.Validation);
}
