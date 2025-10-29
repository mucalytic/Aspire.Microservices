using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface IRequestService
{
    Task<Result<TagsExtractedResponse>> GetTagsExtractedResponseForNote(Note note);
}
