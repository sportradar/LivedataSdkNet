using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Sportradar.LiveData.Sdk.Common.Interfaces;
using Sportradar.LiveData.Sdk.Common.Types;
using Sportradar.LiveData.Sdk.Services.SdkConfiguration.ConfigFactory;

namespace Sportradar.LiveData.Sdk.TestApp
{
    public class Program
    {
        private static ILog _log;
        
        
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            
            _log = LogManager.GetLogger(typeof(Program));
            
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

                WriteLogState();
                Console.ReadLine();
            }
            finally
            {
                sdk.Stop();
            }
        }
        
        private static void SdkOnOnQueueLimits(object sender, QueueLimitEventArgs event_args)
        {
            Console.WriteLine(event_args.NewCount);
        }
        
        
        private static void WriteLogState()
        {
            var loggers1 = LogManager.GetCurrentLoggers();
            
            _log.Error("All current loggers:");
            
            foreach (var logger in loggers1)
            {
                _log.Info($" {logger.Logger.Repository.Name}: {logger.Logger.Name}");
            }
            
            _log.Info("");
            _log.Info("Hierarchy by repository:");
            
            var repos = LogManager.GetAllRepositories();
            
            foreach (var repository in repos)
            {
                _log.Info($"'{repository.Name}' appenders:");
                var hierarchy = (Hierarchy)LogManager.GetRepository(repository.Name);
                var newApp = new ConsoleAppender();
                
                foreach (var appender in hierarchy.GetAppenders())
                {
                    _log.Info($"{appender.Name}");
                    if (appender.Name.Equals("ConsoleAppender"))
                    {
                        newApp = (ConsoleAppender)appender;
                    }
                }
                
                _log.Info($"'{repository.Name}' loggers:");
                var loggers2 = hierarchy.GetCurrentLoggers();
                
                foreach (var logger in loggers2)
                {
                    _log.Info($"{logger.Name}");
                }
                
                _log.Info("");
            }
        }
    }
    
    class MyDeadLetterQueue : IDeadLetterQueue
    {
        public void Enqueue(EntityBase failed_msg)
        {
            Console.WriteLine("Dead letter enqueue!");
            //throw new ArgumentException("dead letter queue exception");
        }
    }
}