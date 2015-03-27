using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl.Matchers;
using QuartzSchedulerDemo.QuartzJobs;
using QuartzSchedulerDemo.QuartzScheduler;
using QuartzSchedulerDemo.QuartzListners;

namespace QuartzSchedulerDemo
{
    /// <summary>
    /// Note: For Creating ADO Job Store 
    /// Download the artigfact  from http://sourceforge.net/projects/quartznet/files/quartznet/ and 
    /// get the required Create Table Script for required DB version.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var scheduler= QuartzScheduler.QuartzScheduler.StartScheduler();
            CustomJob001(scheduler);
            Console.ReadLine();
        }

        public static void  CustomJob001(IScheduler scheduler)
        {
            JobDataMap jobDataMap = new JobDataMap();
            jobDataMap.Add("Param1", DateTime.Now);
            var job= QuartzScheduler.QuartzScheduler.CreateJob<SampleJob>("SampleJob","Group001",jobDataMap);
            var trigger= QuartzScheduler.QuartzScheduler.CreateSinpleTrigger("SampleTrigger", "Group001");
            var jobListner=new SampleJobListner();
            scheduler.ListenerManager.AddJobListener(jobListner,GroupMatcher<JobKey>.GroupEquals("Group001"));
            scheduler.ScheduleJob(job, trigger);
            while (true)
            {
                Thread.Sleep(2000);
            }
        }

    }
}
