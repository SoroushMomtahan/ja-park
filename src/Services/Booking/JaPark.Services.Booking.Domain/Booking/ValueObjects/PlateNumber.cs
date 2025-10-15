using System.Buffers;

namespace JaPark.Services.Booking.Domain.Booking.ValueObjects;

public record Plate
{
    private const string PersianAlphabet = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی";
    private static readonly SearchValues<char> PersianLetters = SearchValues.Create(PersianAlphabet);
    public string Value { get; private set; }
    private Plate(string value) => Value = value;

    public static Result<Plate> From(string value)
    {
        value = value.Trim();
        
        if (
            string.IsNullOrWhiteSpace(value) ||
            value.Length > 8 ||
            !value[..2].All(char.IsDigit) || 
            !PersianLetters.Contains(value[2]) ||
            !value[3..].All(char.IsDigit))
        {
            return Result.Failure<Plate>(BookingErrors.InvalidPlate);
        }

        return new Plate(value);
    }
}
