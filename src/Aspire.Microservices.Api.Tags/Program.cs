using Aspire.Microservices.Api.Tags.Interfaces;
using Aspire.Microservices.Api.Tags.Endpoints;
using Aspire.Microservices.Api.Tags.Services;
using Aspire.Microservices.Api.Tags;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<TagsContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("tags-db")));
builder.EnrichNpgsqlDbContext<TagsContext>();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ITagsService, TagsService>();
builder.Services.AddScoped<IStorageService, StorageService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    var context =  scope.ServiceProvider.GetRequiredService<TagsContext>();
    context.Database.Migrate();
}
app.MapGroup("/api/v{v:apiVersion}")
   .WithApiVersionSet(app.NewApiVersionSet()
       .HasApiVersion(new ApiVersion(1))
       .ReportApiVersions()
       .Build())
   .MapTagEndpoints();
app.UseHttpsRedirection();
app.Run();
