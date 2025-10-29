using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Tags;

public static class Extensions
{
    public static TagsExtractedResponse ToTagsExtractedResponse(this IEnumerable<Tag> tags, Guid noteId) =>
        new(noteId, tags.Select(tag => tag.ToTagResponse()));
    
    public static TagResponse ToTagResponse(this Tag tag) =>
        new(tag.Id, tag.Name, tag.Colour, tag.CreatedAtUtc);
}
