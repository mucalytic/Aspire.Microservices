using Aspire.Microservices.Api.Notes.Interfaces;
using Aspire.Microservices.Api.Notes.Endpoints;
using Aspire.Microservices.Api.Notes.Services;
using Aspire.Microservices.Api.Notes.Options;
using Aspire.Microservices.Api.Notes;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<NotesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("notes-db")));
builder.EnrichNpgsqlDbContext<NotesContext>();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(ApiOptions.ApiVersioningOptions)
                .AddApiExplorer(ApiOptions.ApiExplorerOptions);
builder.Services.AddHttpClient(Constants.HttpClientNames.TagApi, client =>
    client.BaseAddress = new Uri("https+http://tags-api"))
                .ConfigurePrimaryHttpMessageHandler(() =>
                    new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (_, _, _, errors) =>
                        {
                            if (builder.Environment.IsDevelopment()) return true;
                            return errors == SslPolicyErrors.None;
                        }
                    })
                .AddStandardResilienceHandler();
builder.Services.AddScoped<IStorageService, StorageService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<INotesService, NotesService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapGroup("/api/v{v:apiVersion}")
   .WithApiVersionSet(app.NewApiVersionSet()
       .HasApiVersion(new ApiVersion(1))
       .ReportApiVersions()
       .Build())
   .MapNoteEndpoints();
app.UseHttpsRedirection();
app.MigrateDatabase();
app.Run();
