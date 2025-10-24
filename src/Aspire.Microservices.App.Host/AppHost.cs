var builder = DistributedApplication.CreateBuilder(args);
var postgres = builder
       .AddPostgres("postgres")
       .WithHostPort(5432)
       .WithDataVolume()
       .WithLifetime(ContainerLifetime.Persistent);
var notesDb = postgres.AddDatabase("notes"); 
var tagsDb = postgres.AddDatabase("tags"); 
var tagsApi = builder
       .AddProject<Projects.Aspire_Microservices_Api_Tags>("tags-api")
       .WithReference(tagsDb)
       .WaitFor(tagsDb);
builder.AddProject<Projects.Aspire_Microservices_Api_Notes>("notes-api")
       .WithHttpsEndpoint(5001, name: "public")
       .WithReference(notesDb)
       .WithReference(tagsApi)
       .WaitFor(notesDb)
       .WaitFor(tagsApi);
builder.Build().Run();
