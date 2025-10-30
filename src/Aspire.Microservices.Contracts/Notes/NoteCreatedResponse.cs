using Aspire.Microservices.Contracts.Tags;

namespace Aspire.Microservices.Contracts.Notes;

public record NoteCreatedResponse(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedAtUtc,
    IEnumerable<TagResponse> Tags);
