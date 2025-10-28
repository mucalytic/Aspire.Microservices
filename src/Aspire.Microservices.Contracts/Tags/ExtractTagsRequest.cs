namespace Aspire.Microservices.Contracts.Tags;

public record ExtractTagsRequest(Guid NoteId, string Title, string Content);
