using Aspire.Microservices.Api.Notes.Extensions;
using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Contracts.Notes;

namespace Aspire.Microservices.Api.Notes.Endpoints;

public static class NoteEndpoints
{
    public static IEndpointRouteBuilder MapNoteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("note/create", async (CreateNoteRequest request, INotesService notesService) =>
            {
                var result = await notesService.CreateNoteAsync(request);
                return result.IsFailed
                    ? Results.Problem(string.Empty)
                    : Results.Created(Constants.Uris.NoUri, result.Value.ToNoteCreatedResponse());
            })
           .Produces<NoteCreatedResponse>()
           .WithTags(Constants.EndpointNames.Notes)
           .WithOpenApi()
           .MapToApiVersion(1);
        return app;
    }
}
