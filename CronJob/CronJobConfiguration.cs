using CronJob.Implement;
using CronJob.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CronJob
{

    public static class CronJobConfiguration
    {
        public static void ConfigureCronJobServices(this IServiceCollection services)
        {
            //job
            services.AddTransient<ISendNotificationService, SendNotificationService>();            
        }
    }
}
