using Microsoft.EntityFrameworkCore;

namespace Aspire.Microservices.Api.Tags;

public static class Extensions
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        using var context =  scope.ServiceProvider.GetRequiredService<TagsContext>();
        context.Database.Migrate();
        return app;
    }
}
