using Aspire.Microservices.Api.Notes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<NotesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("notes-db")));
builder.EnrichNpgsqlDbContext<NotesContext>();
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var context =  scope.ServiceProvider.GetRequiredService<NotesContext>();
    context.Database.Migrate();
}
app.UseHttpsRedirection();
app.Run();
