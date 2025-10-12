namespace LearnTop.Shared.Infrastructure.Authentication;

public class JwtOptions
{
    public string Audience { get; init; }
    public string Issuer { get; init; }
    public string Secret { get; init; }
    public int AccessTokenExpireTimeByMin { get; init; }
    public int RefreshTokenExpireTimeByMin { get; init; }
}
