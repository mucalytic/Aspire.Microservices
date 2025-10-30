using Aspire.Microservices.Domain.Models;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface IStorageService
{
    Task<Result<Unit>> StoreNoteAsync(Note note);
}
