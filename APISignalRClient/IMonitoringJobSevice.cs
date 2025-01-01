namespace APISignalRClient
{
    public interface IMonitoringJobSevice
    {
        Task<List<string>> GetRunningJobsAsync();
    }
}
