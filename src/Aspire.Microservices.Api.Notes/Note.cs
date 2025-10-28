using Microsoft.Extensions.Diagnostics.Latency;

namespace Aspire.Microservices.Api.Notes;

public class Note
{
    public Guid                Id           { get; set; }
    public string              Title        { get; set; } = string.Empty;
    public string              Content      { get; set; } = string.Empty;
    public DateTime            CreatedAtUtc { get; set; }
    public DateTime?           UpdatedAtUtc { get; set; }
    public IEnumerable<string> Tags         { get; set; } = [];
}
