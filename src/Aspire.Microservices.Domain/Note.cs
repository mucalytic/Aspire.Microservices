namespace Aspire.Microservices.Domain;

public class Note
{
    public Guid             Id           { get; set; }
    public string           Title        { get; set; } = string.Empty;
    public string           Content      { get; set; } = string.Empty;
    public DateTime         CreatedAtUtc { get; set; }
    public DateTime?        UpdatedAtUtc { get; set; }
    public IEnumerable<Tag> Tags         { get; set; } = [];

    public override string ToString() =>
        $"Id: {Id}, Title: {Title}, Content: {Content},  CreatedAtUtc: {CreatedAtUtc}, UpdatedAtUtc: {UpdatedAtUtc}";
}
