using Quartz;

namespace APISignalRClient
{
    public class MonitoringJobSevice : IMonitoringJobSevice
    {
        private readonly IScheduler _scheduler;

        public MonitoringJobSevice(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public async Task<List<string>> GetRunningJobsAsync()
        {
            var runningJobs = new List<string>();

            // Get the list of currently executing jobs
            var currentlyExecutingJobs = await _scheduler.GetCurrentlyExecutingJobs();

            foreach (var jobExecutionContext in currentlyExecutingJobs)
            {
                // You can get job information such as the job key, job name, etc.
                runningJobs.Add($"Job Key: {jobExecutionContext.JobDetail.Key}, Trigger: {jobExecutionContext.Trigger.Key}");
            }

            return runningJobs;
        }

        public async Task<bool> IsJobRunning(string jobName, string jobGroup)
        {
            // Create a job key using the job name and group
            var jobKey = new JobKey(jobName, jobGroup);

            // Get the job details
            var jobDetail = await _scheduler.GetJobDetail(jobKey);

            if (jobDetail == null)
            {
                return false; // Job does not exist
            }

            // Get the triggers associated with the job
            var triggers = await _scheduler.GetTriggersOfJob(jobKey);

            foreach (var trigger in triggers)
            {
                // Check if the job is currently firing
                if (trigger.GetNextFireTimeUtc().HasValue)
                {
                    return true; // Job is running or about to run
                }
            }

            return false; // Job is not running
        }
    }
}
