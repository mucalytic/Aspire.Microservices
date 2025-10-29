using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Contracts.Tags;

namespace Aspire.Microservices.Api.Notes;

public static class Extensions
{
    public static NoteCreatedResponse ToNoteCreatedResponse(this Note note) => new();

    public static ExtractTagsRequest ToExtractTagsRequest(this Note note) =>
        new(note.Id, note.Title, note.Content);
    
    public static IEnumerable<string> ToTags(this IEnumerable<TagResponse> response) =>
        response.Select(r => r.Name).Distinct();
}
