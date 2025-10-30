using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Domain.Models;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Services;

public class StorageService(TagsContext context) : IStorageService
{
    public async Task<Result<Unit>> StoreTags(IEnumerable<Tag> tags)
    {
        try
        {
            context.Tags.AddRange(tags);
            await context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail<Unit>(exception.Message);
        }
    }
}