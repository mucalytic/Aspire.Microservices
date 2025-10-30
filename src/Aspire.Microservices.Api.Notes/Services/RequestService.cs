using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain.Models;
using Aspire.Microservices.Domain;
using System.Text.Json;
using System.Net.Mime;
using FluentResults;
using System.Text;

namespace Aspire.Microservices.Api.Notes.Services;

public class RequestService(IHttpClientFactory clientFactory) : IRequestService
{
    public async Task<Result<TagsExtractedResponse>> GetTagsExtractedResponseForNote(Note note)
    {
        try
        {
            var client = clientFactory.CreateClient(Constants.HttpClientNames.TagApi);
            var json = JsonSerializer.Serialize(note.ToExtractTagsRequest());
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            var message = await client.PostAsync("api/v1/tags/extract", content);
            var response = await message.Content.ReadFromJsonAsync<TagsExtractedResponse>();
            if (response is null) return Result.Fail("Couldn't extract tags from note.");
            return response;
        }
        catch (Exception exception)
        {
            return Result.Fail<TagsExtractedResponse>(exception.Message);
        }
    }
}