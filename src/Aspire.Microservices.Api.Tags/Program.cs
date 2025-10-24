using Aspire.Microservices.Api.Tags;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<TagsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("tags-db")));
builder.EnrichNpgsqlDbContext<TagsContext>();
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var context =  scope.ServiceProvider.GetRequiredService<TagsContext>();
    context.Database.Migrate();
}
app.UseHttpsRedirection();
app.Run();
