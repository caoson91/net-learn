using BlazorRepository;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace CronJob
{
    public static class HangfireRegistrar
    {
        public static void AddHangfireJob(this IGlobalConfiguration globalConfiguaration, IConfiguration configuration)
        {

            RecurringJob.AddOrUpdate<ICategoryService>("GetCategory", job => job.GetAllCategory(), Cron.Daily(6));

        }
    }
}
