var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireOtelTest_ApiService>("apiservice");

builder.AddProject<Projects.AspireOtelTest_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
