using Serilog;
using Serilog.Events;

namespace BrewChain.Extensions;

public static class LoggingExtension
{
    public static void AddSerilogLogging(this IHostBuilder host)
    {   
        // Create as Host, instead of ILogger, to ensure that Serilog is properly integrated with the application's logging infrastructure and can capture logs from all parts of the application, including those generated during startup and shutdown
        host.UseSerilog((context, loggerConfiguration) => 
        {
            loggerConfiguration
                .MinimumLevel.Information() // INFO level for the application
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)  // INFO level for Microsoft logs to capture important framework events without overwhelming the log with debug information
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information) // INFO level for hosting lifetime logs to capture application start and stop events
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning) // WARNING level for EF Core logs to reduce noise
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                );
        });
    }
}
