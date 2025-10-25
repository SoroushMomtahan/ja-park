using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JaPark.Shared.Infrastructure.Authentication;

internal sealed class JwtOptionsSetup(IConfiguration configuration) : IConfigureOptions<JwtOptions>
{
    public void Configure(JwtOptions options)
    {
        configuration.GetSection(nameof(JwtOptions)).Bind(options);
    }
}
