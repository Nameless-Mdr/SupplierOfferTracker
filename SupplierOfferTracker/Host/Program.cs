using System.Reflection;
using Infrastructure.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services
    .AddInfrastructureServices(configuration);

services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

services.AddEndpointsApiExplorer();

services.AddSwaggerGen(swagger =>
{
    var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
    var xmlFilename = $"{assemblyName}.xml";
    var pathToXmlComments = Path.Combine(AppContext.BaseDirectory, xmlFilename);

    swagger.SwaggerDoc("v1", new OpenApiInfo { Title = $"{assemblyName} Swagger", Version = "v1" });
    swagger.ResolveConflictingActions(apiDesc => apiDesc.First());
    swagger.IncludeXmlComments(pathToXmlComments);
});

await services.ApplyMigrations();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.Run();