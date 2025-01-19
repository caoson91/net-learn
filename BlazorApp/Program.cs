using BlazorApp.Components;
using BlazorRepository;
using BlazorUtilities;
using CronJob;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt
            .UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddServices();
builder.Services.ConfigureCronJobServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<SignalRService>();
builder.Services.AddSingleton<SignalRService3>();

//// Add Hangfire services.
//builder.Services.AddHangfire(configuration => configuration
//    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
//    .UseSimpleAssemblyNameTypeSerializer()
//    .UseRecommendedSerializerSettings()
//    .UseSqlServerStorage(builder.Configuration.GetConnectionString("ConnectionString"))
//    .AddHangfireJob(builder.Configuration));


//// Add the processing server as IHostedService
//builder.Services.AddHangfireServer();

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/log-.log", rollingInterval: RollingInterval.Day)
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(); // Replace the default .NET logger


var app = builder.Build();

//app.UseHangfireDashboard();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
