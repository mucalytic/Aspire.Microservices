using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;

namespace Aspire.Microservices.Api.Notes;

public static class Extensions
{
    public static NoteCreatedResponse ToNoteCreatedResponse(this Note note) => new();

    public static ExtractTagsRequest ToExtractTagsRequest(this Note note) =>
        new(note.Id, note.Title, note.Content);
    
    public static IEnumerable<Tag> ToTags(this IEnumerable<TagResponse> response, Guid noteId) =>
        response
            .Select(r =>
                new Tag
                {
                    Id = r.TagId,
                    Name = r.Name,
                    NoteId = noteId,
                    Colour = r.Colour,
                    CreatedAtUtc = r.CreatedAtUtc
                })
            .Distinct();
}
