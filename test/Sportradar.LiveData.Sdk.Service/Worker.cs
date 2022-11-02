using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Sportradar.LiveData.Sdk.Common.Interfaces;
using Sportradar.LiveData.Sdk.Common.Types;
using Sportradar.LiveData.Sdk.Services.SdkConfiguration.ConfigFactory;

namespace Sportradar.LiveData.Sdk.Service
{
    public class Worker : BackgroundService
    {
        public Worker()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var sdk = Services.Sdk.Instance;

            try
            {
                var cfg_factory = AppConfigFactory.FromSection("Sdk");

                sdk.Initialize(cfg_factory, new MyDeadLetterQueue());
                sdk.Start();

                sdk.OnQueueLimits += SdkOnOnQueueLimits;

                if (sdk.LiveScout != null)
                {
                    sdk.LiveScout.Start();
                    var live_scout_test = new LiveScoutTest();
                    live_scout_test.Run();
                }

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
            finally
            {
                sdk.Stop();
            }
        }

        private static void SdkOnOnQueueLimits(object sender, QueueLimitEventArgs event_args) => 
            Console.WriteLine(event_args.NewCount);
    }

    internal class MyDeadLetterQueue : IDeadLetterQueue
    {
        public void Enqueue(EntityBase failed_msg) => Console.WriteLine("Dead letter enqueue!");
    }
}
