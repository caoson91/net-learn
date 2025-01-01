using BlazorUtilities;
using Quartz;
using System.Formats.Asn1;

namespace APISignalRClient
{
    public class SampleJob : IJob
    {
        private readonly SignalRService _signalRService;
        //private readonly MonitoringJobSevice _monitoringJobSevice;

        public SampleJob(SignalRService signalRService
            //MonitoringJobSevice monitoringJobSevice
            )
        {
            _signalRService = signalRService;
           // _monitoringJobSevice = monitoringJobSevice;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            //var listRunningJobs = await _monitoringJobSevice.GetRunningJobsAsync();
            //if (listRunningJobs.Any()) return;

            // Job logic here
            await Console.Out.WriteLineAsync("Executing Sample Job 11111111111111111111111111111111111111! ------------------------------------------------------------------");

            await _signalRService.ConnectAsync();

            for (int i = 1; i < 1000; i++)
            {
                string guiId = Guid.NewGuid().ToString();
                await _signalRService.SendMessageAsync("APISignalRClient 11111", guiId + " - APISignalRClient " + i, guiId);

                await Task.Delay(2000);
            }

        }
    }
}
