using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Contracts.Tags;
using Aspire.Microservices.Domain;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Services;

public class TagsService(ILogger<TagsService> logger) : ITagsService
{
    public Result<IEnumerable<Tag>> ExtractTags(ExtractTagsRequest request)
    {
        throw new NotImplementedException();
    }
}
