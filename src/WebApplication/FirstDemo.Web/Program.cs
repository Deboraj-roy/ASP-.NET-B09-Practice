using Autofac.Extensions.DependencyInjection;
using Autofac; 
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FirstDemo.Web;
using Serilog;
using Serilog.Events;
using FirstDemo.Application;
using FirstDemo.Infrastructure;
using System.Reflection;
using FirstDemo.Infrastructure.Extensions;
using FirstDemo.Infrastructure.Email;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using FirstDemo.Infrastructure.Membership;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
    var migrationAssembly = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule(connectionString,
            migrationAssembly));
        containerBuilder.RegisterModule(new WebModule());
    });


    // Add services to the container.
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString,
        (m) => m.MigrationsAssembly(migrationAssembly)));

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddIdentity();

    builder.Services.AddControllersWithViews();
    builder.Services.AddCookieAuthentication();
    builder.Services.Configure<Smtp>(builder.Configuration.GetSection("Smtp"));

    builder.Services.AddAuthorization( options =>
    {
        options.AddPolicy("SupperAdmin", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireRole(UserRoles.Admin);
            policy.RequireRole(UserRoles.Supervisor);
        });

        options.AddPolicy("CourseViewPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("ViewCourse", "true");
        });

        options.AddPolicy("CourseUpdatePolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("UpdateCourse", "true");
        });

        //options.AddPolicy("CourseViewRequirementPolicy", policy =>
        //{
        //    policy.RequireAuthenticatedUser();
        //    policy.Requirements.Add(new CourseViewRequirement());
        //});
    });

    //For Docker container
    builder.Services.Configure<KestrelServerOptions>(builder.Configuration.GetSection("Kestrel"));
    //builder.WebHost.UseUrls("http://*:80");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
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
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();

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
