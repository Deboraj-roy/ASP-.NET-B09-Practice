using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using StockData.Application;
using StockData.Infrastructure;
using StockData.Worker;

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var migrationAssembly = typeof(ScrapData).Assembly.FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();


try
{
    Log.Information("Application Starting up");

    var host = Host.CreateDefaultBuilder(args)
         .UseWindowsService()
         .UseServiceProviderFactory(new AutofacServiceProviderFactory())
         .UseSerilog()
         .ConfigureContainer<ContainerBuilder>(builder =>
         {
             builder.RegisterModule(new InfrastructureModule());
             builder.RegisterModule(new ApplicationModule());
         })
         .ConfigureServices(services =>
         {
             services.AddHostedService<ScrapData>();
             services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                (m) => m.MigrationsAssembly(migrationAssembly)));
         })
         .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}
