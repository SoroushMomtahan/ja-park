using System.Buffers;
using JaPark.Services.Promotions.Domain.CouponPolicies.Errors;

namespace JaPark.Services.Promotions.Domain.CouponPolicies.ValueObjects;

public record PlateNumber
{
    private const string PersianAlphabet = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی";
    private static readonly SearchValues<char> PersianLetters = SearchValues.Create(PersianAlphabet);
    public string Value { get; private set; }
    private PlateNumber(string value) => Value = value;

    public static Result<PlateNumber> From(string value)
    {
        value = value.Trim();
        
        if (
            string.IsNullOrWhiteSpace(value) ||
            value.Length > 8 ||
            !value[..2].All(char.IsDigit) || 
            !PersianLetters.Contains(value[2]) ||
            !value[3..].All(char.IsDigit))
        {
            return Result.Failure<PlateNumber>(CouponPolicyErrors.InvalidPlate);
        }

        return new PlateNumber(value);
    }
}

