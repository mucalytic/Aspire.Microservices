using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Contracts.Tags;

namespace Aspire.Microservices.Api.Tags.Endpoints;

public static class TagEndpoints
{
    public static IEndpointRouteBuilder MapTagEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("tags/extract", async (ExtractTagsRequest request, ITagsService tagsService) =>
            {
                var result = await tagsService.ExtractTagsAsync(request);
                return result.IsFailed
                    ? Results.Problem(string.Empty)
                    : Results.Created(Constants.Uris.NoUri, new TagsExtractedResponse(request.NoteId, result.Value));
            })
           .Produces<TagsExtractedResponse>()
           .WithTags(Constants.EndpointNames.Tags)
           .WithOpenApi()
           .MapToApiVersion(1);
        return app;
    }
}
