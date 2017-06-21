namespace SerilogSeqIssue70
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    
    using Serilog;
    using Serilog.Core;

    public static class SampleFunction
    {
        [FunctionName("SampleFunction")]
        public static void Run([TimerTrigger("*/1 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            var seqUrl = "http://localhost:5341/";
            var seqApiKey = "";
            var levelSwitch = new LoggingLevelSwitch();

            var loggerConfiguration = new LoggerConfiguration()
                .WriteTo.Seq(seqUrl, apiKey: seqApiKey, controlLevelSwitch: levelSwitch)
                .MinimumLevel.ControlledBy(levelSwitch);

            var logger = loggerConfiguration.CreateLogger();

            Log.Logger = logger;
        }
    }
}