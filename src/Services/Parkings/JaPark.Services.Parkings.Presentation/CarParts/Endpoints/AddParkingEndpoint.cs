using JaPark.Services.Parkings.Application.CarParts.Features.Commands.AddParkingCommand;
using JaPark.Services.Parkings.Domain.CarParts.Enums;

namespace JaPark.Services.Parkings.Presentation.CarParts.Endpoints;

internal sealed class AddParkingEndpoint : IEndpoint
{
    public sealed record AddParkingRequest(
        string ParkingName,
        string ParkingMapAddress,
        string ParkingTextAddress,
        ParkingType Type);

    public sealed record AddParkingResponse(string ParkingId);
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Parkings", async (
            AddParkingRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            AddParkingCommand command = ToCommand(request);
            Result<AddParkingResult> resultOrError = await sender.Send(command, cancellationToken);
            Result<AddParkingResponse> responseOrError = ToResponse(resultOrError);
            return responseOrError.Match(Results.Created, ApiResults.Problem);
        })
        .WithTags(Tags.Parking)
        .WithName(nameof(AddParkingEndpoint))
        .WithSummary("Creates a new parking facility.")
        .WithDescription("Creates a new parking facility " +
                         "based on the provided data. " +
                         "Returns the ID of the newly created parking.")
        .Accepts<AddParkingRequest>(
            MediaTypeNames.Application.Json)
        .Produces<AddParkingResponse>(
            StatusCodes.Status201Created, 
            MediaTypeNames.Application.Json)
        .Produces(
            StatusCodes.Status406NotAcceptable)
        .Produces<ValidationError>(
            StatusCodes.Status400BadRequest, 
            MediaTypeNames.Application.Json);
    }

    private static AddParkingCommand ToCommand(AddParkingRequest request)
    {
        return new AddParkingCommand(
            request.ParkingName,
            request.ParkingMapAddress,
            request.ParkingTextAddress,
            request.Type);
    }

    private static Result<AddParkingResponse> ToResponse(Result<AddParkingResult> result)
    {
        return result.IsFailure ? 
            Result.Failure<AddParkingResponse>(result.Error) : 
            new AddParkingResponse(result.Value.ParkingId);
    }
}
