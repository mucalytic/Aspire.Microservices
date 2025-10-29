using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Contracts.Tags;

namespace Aspire.Microservices.Api.Tags.Endpoints;

public static class TagEndpoints
{
    public static IEndpointRouteBuilder MapTagEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("tags/extract", (ExtractTagsRequest request, ITagsService tagsService) =>
            {
                return Results.Ok();
            })
           .Produces<IEnumerable<TagResponse>>()
           .WithTags(Constants.EndpointNames.Tags)
           .WithOpenApi()
           .MapToApiVersion(1);
        return app;
    }
}
