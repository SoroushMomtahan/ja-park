using JaPark.Shared.Domain.Errors;

namespace JaPark.Services.Penalize.Domain.Penalize.Errors;

public static class PenalizeErrors
{
    public static readonly Error InvalidPlate = new(
        "PenalizeErrors.InvalidPlate",
        "پلاک وارد شده صحیح نمی باشد.",
        ErrorType.Validation);
}
