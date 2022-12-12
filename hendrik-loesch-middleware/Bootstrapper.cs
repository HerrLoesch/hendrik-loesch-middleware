

using hendrik_loesch_middleware;
using NLog;

public class Bootstrapper
{
    public static void Run(string[] args)
    {
        var logger = ConfigLogger();

        logger.Debug("Start configuring application.");
        var webApplication = ConfigerWebApplication(args);

        try
        {
            logger.Debug("Start application");
            webApplication.Run();
        }
        catch (Exception exception)
        {
            //NLog: catch setup errors
            logger.Error(exception, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
        }        
    }

    private static Logger ConfigLogger()
    {
        var logger = LogManager.Setup().LoadConfiguration(builder => {
            builder.ForLogger().FilterMinLevel(NLog.LogLevel.Debug).WriteToConsole();
            builder.ForLogger().FilterMinLevel(NLog.LogLevel.Debug).WriteToFile(fileName: "App_${shortdate}.log");
        });

        return logger.GetCurrentClassLogger();;
    }

    private static WebApplication ConfigerWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

        // Add services to the container.
        builder.Services.AddGrpc();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<TypeService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        return app;
    }
}