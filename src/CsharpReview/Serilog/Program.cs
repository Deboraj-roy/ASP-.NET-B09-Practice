using Serilog;
using System.Diagnostics;
using Mailtrap.Source.Models;
using Serilog.Events;
using Serilog.Sinks.Email;

Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Email(
               fromEmail: "your-email@example.com",
               toEmail: "recipient-email@example.com",
               mailServer: "your-smtp-server",
               outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
           .CreateLogger();

try
{
    Log.Information("Application starting up");
    // Run your application
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly.");
}
finally
{
    Log.CloseAndFlush();
}