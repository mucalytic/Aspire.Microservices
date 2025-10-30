using Microsoft.EntityFrameworkCore;

namespace Aspire.Microservices.Api.Notes;

public static class Extensions
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context =  scope.ServiceProvider.GetRequiredService<NotesContext>();
        context.Database.Migrate();
        return app;
    }
}
