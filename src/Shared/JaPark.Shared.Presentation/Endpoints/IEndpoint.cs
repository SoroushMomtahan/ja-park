using Microsoft.AspNetCore.Routing;

namespace JaPark.Shared.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
