using HealthChecks.UI.Client;
using IntegrationAISII.API;
using IntegrationAISII.API.Infrastructure;
using IntegrationAISII.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
//TODO: Дописать логирование и создать Startup
App.Name = builder.Environment.ApplicationName;

try
{

    Log.Logger = CreateSerilogLogger(builder.Configuration);

    Log.Information("Applying migrations ({ApplicationContext})...", App.Name);

    // Add services to the container.

    builder.Services
        .AddApplicationServices(builder.Configuration)
        .AddCustomHealthCheck(builder.Configuration);
        //.AddCustomDbContext(builder.Configuration);
    builder.Services
        .AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services
        .AddEndpointsApiExplorer();
    builder.Services
        .AddSwaggerGen();

    var app = builder.Build();

    Log.Information("Configuring web host ({ApplicationContext})...", App.Name);
    LogPackagesVersionInfo();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    //app.UseAuthorization();
    //app.MapControllers();
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}");
        endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        endpoints.MapHealthChecksUI(config => config.UIPath = "/hc-ui");
    });
    Log.Information("Starting web host ({ApplicationContext})...", App.Name);

    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", App.Name);
    return 1;
}
finally
{
    Log.CloseAndFlush();
}


Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
{
    var seqServerUrl = configuration["Serilog:SeqServerUrl"];
    var logstashUrl = configuration["Serilog:LogstashgUrl"];
    return new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationContext", App.Name)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "https://seq" : seqServerUrl)
        .WriteTo.Http(string.IsNullOrWhiteSpace(logstashUrl) ? "https://logstash:8080" : logstashUrl, 1000)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

string GetVersion(Assembly assembly)
{
    try
    {
        return $"{assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version} ({assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split()[0]})";
    }
    catch
    {
        return string.Empty;
    }
}

void LogPackagesVersionInfo()
{
    var assemblies = new List<Assembly>();

    foreach (var dependencyName in typeof(Program).Assembly.GetReferencedAssemblies())
    {
        try
        {
            // Try to load the referenced assembly...
            assemblies.Add(Assembly.Load(dependencyName));
        }
        catch
        {
            // Failed to load assembly. Skip it.
        }
    }

    var versionList = assemblies.Select(a => $"-{a.GetName().Name} - {GetVersion(a)}").OrderBy(value => value);

    Log.Logger.ForContext("PackageVersions", string.Join("\n", versionList)).Information("Package versions ({ApplicationContext})", App.Name);
}


public class App
{
    public static string Name;
}
