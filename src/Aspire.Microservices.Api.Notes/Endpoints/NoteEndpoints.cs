using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Notes.Endpoints;

public static class NoteEndpoints
{
    public static IEndpointRouteBuilder MapNoteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("note/{id:guid}", (Guid id) => Results.NoContent())
            .WithName(Constants.EndpointNames.GetNoteById)
            .WithTags(Constants.EndpointNames.Notes)
            .WithOpenApi()
            .MapToApiVersion(1);

        app.MapPost("note/create", async (CreateNoteRequest request, INotesService notesService, ILogger<Program> logger) =>
            {
                var result = await notesService.CreateNoteAsync(request);
                logger.LogInformation("Returning note: {Note}", result.Value);
                return result.IsFailed
                    ? Results.Problem(string.Empty)
                    : Results.CreatedAtRoute(
                        Constants.EndpointNames.GetNoteById,
                        new { id =  result.Value.Id },
                        result.Value.ToNoteCreatedResponse());
            })
           .Produces<NoteCreatedResponse>()
           .WithTags(Constants.EndpointNames.Notes)
           .WithOpenApi()
           .MapToApiVersion(1);
        return app;
    }
}
