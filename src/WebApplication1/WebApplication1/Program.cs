using Serilog.Events;
using Serilog.Sinks.Email;
using Serilog;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    // Add services to the container.
    builder.Services.AddControllersWithViews();


 // Other service configurations
   /* Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Error()
        .WriteTo.Console()
        .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.Email(new EmailConnectionInfo
        {
            FromEmail = "your@email.com",
            ToEmail = "destination@email.com",
            MailServer = "sandbox.smtp.mailtrap.io",
            NetworkCredentials = new NetworkCredential("05e65c2fff2222", "21725a0f9efa6f"),
            Port = 587,
            EnableSsl = true,
            EmailSubject = "Fatal Error Notification",
        }, restrictedToMinimumLevel: LogEventLevel.Fatal)
        .CreateLogger();
*/
    // Other configurations


    Log.Logger = new LoggerConfiguration()
       .WriteTo.Console()
       .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
       .WriteTo.Email(new EmailConnectionInfo
       {
           FromEmail = "your@email.com",
           ToEmail = "admin@email.com",
           MailServer = "sandbox.smtp.mailtrap.io",
           NetworkCredentials = new NetworkCredential("05e65c2fff2222", "21725a0f9efa6f"),
           EnableSsl = true,
           Port = 587,
           EmailSubject = "Fatal Error in Your Application"
       }, restrictedToMinimumLevel: LogEventLevel.Fatal)
       .CreateLogger();

    builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());


    var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();

    Log.Information("Application Starting...");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Failed to start application.");
}
finally
{
    Log.CloseAndFlush();
}
