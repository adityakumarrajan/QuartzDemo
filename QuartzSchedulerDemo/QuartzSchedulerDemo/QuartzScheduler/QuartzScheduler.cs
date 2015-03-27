using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace QuartzSchedulerDemo.QuartzScheduler
{
    /// <summary>
    /// This Class is responsible for Scheduler Instance.
    /// </summary>
    public static class QuartzScheduler
    {
        public static readonly ISchedulerFactory objSchedulerFactory = new StdSchedulerFactory();

        public static IScheduler StartScheduler()
        {
            try
            {
                IScheduler objScheduler = objSchedulerFactory.GetScheduler();
                objScheduler.Start();
                return objScheduler;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static IJobDetail CreateJob<T>(string jobName, string groupName,JobDataMap jobDataMap) where T : IJob
        {
            IJobDetail job = JobBuilder.Create<T>()
                .WithIdentity(jobName, groupName)
                .Build();
                
            foreach (var item in jobDataMap)
            {
                job.JobDataMap.Add(item.Key, item.Value);
            }
            return job;
        }

        public static ITrigger CreateSinpleTrigger(string triggerName, string groupName, JobDataMap jobDataMap=null)
        {
            ITrigger trigger = TriggerBuilder.Create()
                               .WithIdentity(triggerName, groupName)
                               .StartNow()
                               .WithSimpleSchedule(x => x.WithIntervalInSeconds(40).RepeatForever())
                               .Build();
            if (jobDataMap != null)
            {
                foreach (var item in jobDataMap)
                {
                    trigger.JobDataMap.Add(item.Key, item.Value);
                }
            }
            return trigger;
        }

        public static void CreateCronTrigger(string triggerName, string groupName, JobDataMap jobDataMap = null)
        {
            //This trigger will run every other minute betwewen 8 AM to 5 PM.
            ITrigger trigger = TriggerBuilder.Create()
                            .WithIdentity(triggerName,groupName)
                            .WithCronSchedule("0 0/2 8-17 * * ?")
                            .Build();
            foreach (var item in jobDataMap)
            {
                trigger.JobDataMap.Add(item.Key, item.Value);
            }
        }
    }
}
