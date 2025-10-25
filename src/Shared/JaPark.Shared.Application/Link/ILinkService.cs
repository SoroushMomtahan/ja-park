namespace JaPark.Shared.Application.Link;

public interface ILinkService
{
    LinkDto Generate(
        string endpointName,
        string rel,
        string method,
        object? values = null,
        string? controllerName = null);
}
