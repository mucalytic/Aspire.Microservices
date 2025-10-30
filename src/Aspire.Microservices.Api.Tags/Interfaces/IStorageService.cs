using Aspire.Microservices.Domain.Models;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Tags.Interfaces;

public interface IStorageService
{
    Task<Result<Unit>> StoreTags(IEnumerable<Tag> tags);
}