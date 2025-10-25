using JaPark.Shared.Domain.Results;

namespace JaPark.Shared.Domain.Errors;

public sealed record ValidationError(Error[] Errors) : Error("General.Validation",
    "یک یا چند خطای اعتبارسنجی رخ داد",
    ErrorType.Validation)
{

    public static ValidationError FromResults(IEnumerable<Result> results)
    {
        return new(results.Where(static r => r.IsFailure).Select(static r => r.Error).ToArray());
    }
}

