using Aspire.Microservices.Api.Notes.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Contracts.Tags;
using System.Text.Json;
using FluentResults;
using System.Text;

namespace Aspire.Microservices.Api.Notes.Services;

public class NotesService(
    NotesContext context,
    ILogger<NotesService> logger,
    IHttpClientFactory clientFactory) : INotesService
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
            var client = clientFactory.CreateClient(Constants.HttpClientNames.TagApi);
            var json = JsonSerializer.Serialize(note.ToExtractTagsRequest());
            var content = new StringContent(json, Encoding.UTF8, Application.Json);
            var message = await client.PostAsync("api/v1/tags/extract", content);
            var response = await message.Content.ReadFromJsonAsync<TagsResponse>();
            if (response is not null) note.Tags = response.ToTags();
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            return note;
        }
        catch (Exception exception)
        {
            logger.LogError(exception, exception.Message);
            return Result.Fail<Note>(exception.Message);
        }
    }
}
