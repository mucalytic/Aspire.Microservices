namespace Aspire.Microservices.Contracts.Tags;

public record TagsExtractedResponse(Guid NoteId, IEnumerable<TagResponse> Tags);
