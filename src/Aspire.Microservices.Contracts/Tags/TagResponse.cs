namespace Aspire.Microservices.Contracts.Tags;

public record TagResponse(Guid TagId, string Name, string Colour, DateTime CreatedAtUtc);
