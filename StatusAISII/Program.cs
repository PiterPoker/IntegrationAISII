using Serilog;
using StatusAISII.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
//TODO: Дописать логирование и создать Startup
string AppName = builder.Environment.ApplicationName;

// Add services to the container.
try
{

    Log.Logger = CreateSerilogLogger(builder.Configuration);

    builder.Services
        .AddCustomHealthCheck(builder.Configuration);
    builder.Services
        .AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services
        .AddEndpointsApiExplorer();
    /*builder.Services
        .AddSwaggerGen();*/

    var app = builder.Build();

    Log.Information("Configuring web host ({ApplicationContext})...", AppName);
    LogPackagesVersionInfo();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        /*app.UseSwagger();
        app.UseSwaggerUI();*/
    }

    //app.UseHttpsRedirection();
    //app.UseAuthorization();
    //app.MapControllers();
    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapHealthChecksUI(config =>
        {
            config.ResourcesPath = "/hc-ui";
            config.UIPath = "/hc-ui";
        });
        //endpoints.MapHealthChecksUI(config => config.UIPath = "/hc-ui");
    });
    Log.Information("Starting web host ({ApplicationContext})...", AppName);

    app.Run();
    return 0;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
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
        .Enrich.WithProperty("ApplicationContext", AppName)
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

    Log.Logger.ForContext("PackageVersions", string.Join("\n", versionList)).Information("Package versions ({ApplicationContext})", AppName);
}