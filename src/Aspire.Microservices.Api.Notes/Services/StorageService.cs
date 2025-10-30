using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Domain.Models;
using System.Reactive;
using FluentResults;

namespace Aspire.Microservices.Api.Notes.Services;

public class StorageService(NotesContext context) : IStorageService
{
    public async Task<Result<Unit>> StoreNoteAsync(Note note)
    {
        try
        {
            context.Notes.Add(note);
            await context.SaveChangesAsync();
            return Result.Ok();
        }
        catch (Exception exception)
        {
            return Result.Fail<Unit>(exception.Message);
        }
    }
}
