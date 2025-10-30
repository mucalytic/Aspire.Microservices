using Aspire.Microservices.Contracts.Notes;
using Aspire.Microservices.Domain.Models;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Interfaces;

public interface INotesService
{
    Task<Result<Note>> CreateNoteAsync(CreateNoteRequest request);
}
