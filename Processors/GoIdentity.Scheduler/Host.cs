using GoIdentity.Utilities.Constants;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;

namespace GoIdentity.Scheduler
{
    [System.ComponentModel.DesignerCategory("Code")]
    internal sealed partial class Host : ServiceBase
    {
        public const string NameOfService = "GoIdentity Scheduled Jobs";

        private static object _syncLock = new Object();

        /// <summary>
        /// Application entry point.
        /// </summary>
        internal static void Main()
        {
#if (DEBUG)
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("{0} are starting...", NameOfService);
            Console.WriteLine("-----------------------------------------------------------------------");

            //JobHelper.SendPupilSms(null);

            using (Host host = new Host())
            {
                host.OnStart(new string[] { });

                Console.WriteLine("-----------------------------------------------------------------------");
                Console.WriteLine("{0} are listening...Press <ENTER> to terminate.", NameOfService);
                Console.WriteLine("-----------------------------------------------------------------------");

                Console.ReadLine();

                host.OnStop();
            }
#else
            ServiceBase.Run(new Host());            
#endif
        }

        private StdSchedulerFactory schedulerFactory = default(StdSchedulerFactory);
        private IScheduler scheduler = default(IScheduler);

        public Host()
        {
            var currentThread = Thread.CurrentThread;
            currentThread.Name = NameOfService;
            ServiceName = NameOfService;

#if DEBUG
            ConnectionStrings.COMMON_CONNECTION_STRING = ConfigurationManager.AppSettings["COMMON_CONNECTION_STRING"];
            ConnectionStrings.COMMAND_TIMEOUT = 60;

            var processDataJob = new ProcessDataJob();
            processDataJob.Execute(null);
#else
            InitializeContainer();
#endif
        }

        private void InitializeContainer()
        {
            this.schedulerFactory = new StdSchedulerFactory();
            this.scheduler = schedulerFactory.GetScheduler().Result;
            this.scheduler.Start();

            this.RunJobs();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                InitializeContainer();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.OnStart(args);
            }
        }

        public void RunJobs()
        {
            try
            {
                ConnectionStrings.COMMON_CONNECTION_STRING = ConfigurationManager.AppSettings["COMMON_CONNECTION_STRING"];
                ConnectionStrings.COMMAND_TIMEOUT = 60;

                var importDataSetJob = JobBuilder.Create<ProcessDataJob>().WithIdentity("ProcessDataJob", "GoIdentity").Build();
                var importDataSetJobTrigger = TriggerBuilder.Create().WithIdentity("ProcessDataJobTrigger", "GoIdentity").StartNow()
                              .WithSimpleSchedule(x => x
                              .WithIntervalInSeconds(30)
                              .RepeatForever())
                              .Build();

                this.scheduler.ScheduleJob(importDataSetJob, importDataSetJobTrigger);
            }
            catch (Exception ex)
            {
                //EventLogHelper.LogError(ex, string.Format("{0} are failed to start job...", NameOfService));
            }
        }

        protected override void OnStop()
        {
            try
            {
                //EventLogHelper.LogInformation(string.Format("{0} are shut down...", NameOfService));
            }
            finally
            {
                base.OnStop();
            }
        }
    }
}
