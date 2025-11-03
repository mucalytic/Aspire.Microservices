using Microsoft.EntityFrameworkCore;

namespace Aspire.Microservices.Api.Notes;

public static class Extensions
{
    extension(WebApplication app)
    {
        public WebApplication MigrateDatabase()
        {
            using var scope = app.Services.CreateScope();
            using var context =  scope.ServiceProvider.GetRequiredService<NotesContext>();
            context.Database.Migrate();
            return app;
        }
    }
}
