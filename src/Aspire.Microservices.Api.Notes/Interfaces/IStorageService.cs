using Aspire.Microservices.Domain;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface IStorageService
{
    Task<Result<Unit>> StoreNoteAsync(Note note);
}
