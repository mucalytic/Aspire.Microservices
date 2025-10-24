var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Aspire_Microservices_Api_Notes>("notes-api");
builder.AddProject<Projects.Aspire_Microservices_Api_Tags>("tags-api");

builder.Build().Run();
