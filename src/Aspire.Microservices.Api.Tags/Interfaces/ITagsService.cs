using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Interfaces;

public interface ITagsService
{
    Task<Result<IEnumerable<Tag>>> ExtractTagsAsync(ExtractTagsRequest request);
}
