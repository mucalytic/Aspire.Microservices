using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Tags.Extensions;

public static class MappingExtensions
{
    public static IEnumerable<TagResponse> ToTagResponses(this IEnumerable<Tag> tags) =>
        tags.Select(tag => new TagResponse(tag.Id, tag.Name, tag.Colour, tag.CreatedAtUtc));
}
