using CBTech.Api.Middleware;
using CBTech.Application;
using CBTech.Infrastructure;
using Serilog;
using CBTech.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithCorrelationId()
    .CreateLogger();

builder.Host.UseSerilog(Log.Logger);

// Add layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddCBTechAuthentication(builder.Configuration);
builder.Services.AddCBTechOpenApi();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Middlewares
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

// Scalar/OpenAPI exposto em Development, LocalDocker e Release (homologação) — útil para
// testes externos. Em Production (VPS) fica desabilitado.
if (app.Environment.IsDevelopment()
    || app.Environment.IsEnvironment("LocalDocker")
    || app.Environment.IsEnvironment("Release"))
{
    app.MapCBTechOpenApi();
}

app.UseCBTechCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapCBTechEndpoints();

try
{
    Log.Information("Iniciando CBTech API (Environment={Env})...", builder.Environment.EnvironmentName);
    await app.InitializeDatabaseAsync();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "API terminou inesperadamente.");
}
finally
{
    Log.CloseAndFlush();
}

// Exposto para os testes de integração (WebApplicationFactory<Program>).
public partial class Program { }
