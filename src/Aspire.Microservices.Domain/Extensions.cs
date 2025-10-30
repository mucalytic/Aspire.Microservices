using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain.Models;

namespace Aspire.Microservices.Domain;

public static class Extensions
{
    public static IEnumerable<TagResponse> ToTagResponses(this IEnumerable<Tag> tags) =>
        tags.Select(tag => new TagResponse(tag.Id, tag.Name, tag.Colour, tag.CreatedAtUtc));
    
    public static NoteCreatedResponse ToNoteCreatedResponse(this Note note) =>
        new(note.Id, note.Title, note.Content, note.CreatedAtUtc, note.Tags.ToTagResponses());

    public static ExtractTagsRequest ToExtractTagsRequest(this Note note) =>
        new(note.Id, note.Title, note.Content);
    
    public static IEnumerable<Tag> ToTags(this TagsExtractedResponse response) =>
        response
            .Tags
            .Select(tag =>
                new Tag
                {
                    Id = tag.TagId,
                    Name = tag.Name,
                    Colour = tag.Colour,
                    NoteId = response.NoteId,
                    CreatedAtUtc = tag.CreatedAtUtc
                })
            .Distinct();
}
