using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Notes.Extensions;

public static class MappingExtensions
{
    public static NoteCreatedResponse ToNoteCreatedResponse(this Note note) => new();

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
