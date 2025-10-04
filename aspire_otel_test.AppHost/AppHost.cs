var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.aspire_otel_test>("aspire-otel-test");

builder.Build().Run();
