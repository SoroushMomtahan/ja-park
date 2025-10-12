using Microsoft.AspNetCore.Routing;

namespace LearnTop.Shared.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
