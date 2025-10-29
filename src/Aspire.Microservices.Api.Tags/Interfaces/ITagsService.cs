using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Interfaces;

public interface ITagsService
{
    Result<IEnumerable<Tag>> ExtractTags(ExtractTagsRequest request);
}
