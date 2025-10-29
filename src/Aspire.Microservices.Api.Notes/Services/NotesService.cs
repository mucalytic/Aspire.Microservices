using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Domain;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Services;

public class NotesService(
    IRequestService requestService,
    IStorageService storageService,
    ILogger<NotesService> logger) : INotesService
{
    public async Task<Result<Note>> CreateNoteAsync(CreateNoteRequest createNoteRequest)
    {
        try
        {
            var note = new Note
            {
                Id = Guid.CreateVersion7(),
                CreatedAtUtc = DateTime.UtcNow,
                Title = createNoteRequest.Title,
                Content = createNoteRequest.Content
            };
            var getTagsResult = await requestService.GetTagsExtractedResponseForNote(note);
            if (getTagsResult.IsSuccess)
            {
                var tags = getTagsResult.Value.ToTags();
                logger.LogInformation("Got tags from endpoint: {Tags}", tags);
                note.Tags = tags;
            }
            var storeNoteResult = await storageService.StoreNoteAsync(note);
            if (storeNoteResult.IsSuccess)
            {
                logger.LogInformation("Created and stored note: {Note}", note);
            }
            return note;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception: {Message}", exception.Message);
            return Result.Fail<Note>(exception.Message);
        }
    }
}
