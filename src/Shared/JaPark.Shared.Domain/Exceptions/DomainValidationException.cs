namespace LearnTop.Shared.Domain;

public class DomainValidationException(Error error) : Exception
{
    public Error Error { get; } = error;

}
