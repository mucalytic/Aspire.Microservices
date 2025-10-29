using Aspire.Microservices.Domain;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Interfaces;

public interface IStorageService
{
    Task<Result<Unit>> StoreTags(IEnumerable<Tag> tags);
}