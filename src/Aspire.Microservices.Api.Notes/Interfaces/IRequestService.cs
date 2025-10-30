using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain.Models;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface IRequestService
{
    Task<Result<TagsExtractedResponse>> GetTagsExtractedResponseForNote(Note note);
}
