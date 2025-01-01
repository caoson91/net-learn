using APISignalRClient;
using BlazorUtilities;
using Quartz;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<SignalRService>();
builder.Services.AddSingleton<SignalRService3>();
//builder.Services.AddScoped<IMonitoringJobSevice, MonitoringJobSevice>();

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();

    // Register the job with Quartz
    var jobKey = new JobKey("SampleJob");
    q.AddJob<SampleJob>(opts => opts.WithIdentity(jobKey));

    // Schedule the job
    q.AddTrigger(opts => opts
        .ForJob(jobKey) // Link to the SampleJob
        .WithIdentity("SampleJob-trigger") // Unique trigger ID
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10) // Trigger every 10 seconds
            .RepeatForever()));        // Repeat indefinitely

    var jobKey2 = new JobKey("SampleJob2");
    q.AddJob<SampleJob2>(opts => opts.WithIdentity(jobKey2));

    // Schedule the job
    q.AddTrigger(opts => opts
        .ForJob(jobKey2) // Link to the SampleJob
        .WithIdentity("SampleJob2-trigger") // Unique trigger ID
        .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10) // Trigger every 10 seconds
            .RepeatForever()));        // Repeat indefinitely
});

// Add Quartz Hosted Service
builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
