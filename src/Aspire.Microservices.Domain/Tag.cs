namespace Aspire.Microservices.Domain;

public class Tag
{
    public Guid     Id           { get; set; }
    public string   Name         { get; set; } = string.Empty;
    public string   Colour       { get; set; } = string.Empty;
    public Guid     NoteId       { get; set; }
    public DateTime CreatedAtUtc { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Name: {Name}, Colour: {Colour}, NoteId: {NoteId},  CreatedAtUtc: {CreatedAtUtc}";
}
