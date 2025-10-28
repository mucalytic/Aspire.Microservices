using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Contracts.Notes;

namespace Aspire.Microservices.Api.Notes.Endpoints;

public static class NoteEndpoints
{
    public static IEndpointRouteBuilder MapNoteEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("note/create", (CreateNoteRequest request, INotesService notesService, IHttpClientFactory clientFactory) =>
            {
                return Results.Ok();
            })
            .Produces<NoteCreatedResponse>()
            .WithTags(Constants.EndpointNames.Notes)
            .WithOpenApi()
            .MapToApiVersion(1);
        
        return app;
    }
}
