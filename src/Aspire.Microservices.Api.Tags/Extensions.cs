using Microsoft.EntityFrameworkCore;

namespace Aspire.Microservices.Api.Tags;

public static class Extensions
{
    extension(WebApplication app)
    {
        public WebApplication MigrateDatabase()
        {
            using var scope = app.Services.CreateScope();
            using var context =  scope.ServiceProvider.GetRequiredService<TagsContext>();
            context.Database.Migrate();
            return app;
        }
    }
}
