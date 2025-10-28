using Aspire.Microservices.Contracts.Notes;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface INotesService
{
    Task<Result<Note>> CreateNoteAsync(CreateNoteRequest request);
}
