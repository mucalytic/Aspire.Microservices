using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Tags.Endpoints;

public static class TagEndpoints
{
    public static IEndpointRouteBuilder MapTagEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("tags/{noteId:guid}", (Guid noteId) => Results.NoContent())
            .WithName(Constants.EndpointNames.GetTagsByNoteId)
            .WithTags(Constants.EndpointNames.Tags)
            .WithOpenApi()
            .MapToApiVersion(1);

        app.MapPost("tags/extract", async (ExtractTagsRequest request, ITagsService tagsService) =>
            {
                var result = await tagsService.ExtractTagsAsync(request);
                return result.IsFailed
                    ? Results.Problem(string.Empty)
                    : Results.CreatedAtRoute(
                        Constants.EndpointNames.GetTagsByNoteId,
                        new { noteId = request.NoteId },
                        new TagsExtractedResponse(request.NoteId, result.Value.ToTagResponses()));
            })
           .Produces<TagsExtractedResponse>()
           .WithTags(Constants.EndpointNames.Tags)
           .WithOpenApi()
           .MapToApiVersion(1);
        return app;
    }
}
