using BlazorUtilities;
using Quartz;
using System.Formats.Asn1;

namespace APISignalRClient
{
    public class SampleJob2 : IJob
    {
        private readonly SignalRService _signalRService;
        private readonly MonitoringJobSevice _monitoringJobSevice;

        public SampleJob2(SignalRService signalRService,
            MonitoringJobSevice monitoringJobSevice)
        {
            _signalRService = signalRService;
            _monitoringJobSevice = monitoringJobSevice;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var listRunningJobs = await _monitoringJobSevice.GetRunningJobsAsync();
            if (listRunningJobs.Any()) return;

            // Job logic here
            await Console.Out.WriteLineAsync("Executing Sample Job 222222222222222222222222222222! ------------------------------------------------------------------");

            await _signalRService.ConnectAsync();

            for (int i = 1; i < 100; i++) {
                string guiId = Guid.NewGuid().ToString();
                await _signalRService.SendMessageAsync("APISignalRClient 22222", guiId + " - APISignalRClient " + i, guiId);

                await Task.Delay(5000);
            }

        }
    }
}
