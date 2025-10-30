using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain.Models;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Services;

public class TagsService(IStorageService storageService, ILogger<TagsService> logger) : ITagsService
{
    private readonly Dictionary<string, (string Name, string Colour)> _keywords =  new()
    {
        { "work",      ("Work",      "#3B82F6") },
        { "personal",  ("Personal",  "#10B981") },
        { "important", ("Important", "#EF4444") },
        { "urgent",    ("Urgent",    "#F69E0B") },
        { "idea",      ("Idea",      "#8B5CF6") },
        { "meeting",   ("Meeting",   "#06B6D4") },
        { "project",   ("Project",   "#84CC16") },
        { "todo",      ("Todo",      "#F97316") },
        { "reminder",  ("Reminder",  "#EC4899") },
        { "note",      ("Note",      "#6B7280") }
    };
    
    public async Task<Result<IEnumerable<Tag>>> ExtractTagsAsync(ExtractTagsRequest request)
    {
        var text = string.Join(' ', request.Title, request.Content);
        var tags = _keywords
            .Where(kw => text.Contains(kw.Key))
            .Select(kw => new Tag
            {
                Id = Guid.NewGuid(),
                Name = kw.Value.Name,
                NoteId = request.NoteId,
                Colour = kw.Value.Colour,
                CreatedAtUtc = DateTime.UtcNow                
            })
            .ToList();
        logger.LogInformation("Got {Count} tags from extract tags request for note: {NoteId}: {Tags}", tags.Count, request.NoteId, tags);
        var storeTagsResult = await storageService.StoreTags(tags);
        if (storeTagsResult.IsSuccess)
        {
            logger.LogInformation("Stored tags: {Tags}", tags);
        }
        else
        {
            logger.LogInformation("Failed to store tags: {Tags}", tags);
        }
        logger.LogInformation("Returning tags: {Tags}", tags);
        return Result.Ok(tags.AsEnumerable());
    }
}
