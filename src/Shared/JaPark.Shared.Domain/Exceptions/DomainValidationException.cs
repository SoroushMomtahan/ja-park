using JaPark.Shared.Domain.Errors;

namespace JaPark.Shared.Domain.Exceptions;

public class DomainValidationException(Error error) : Exception
{
    public Error Error { get; } = error;

}
