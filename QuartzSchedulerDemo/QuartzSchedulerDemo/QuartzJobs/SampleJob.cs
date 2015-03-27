using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Job;

namespace QuartzSchedulerDemo.QuartzJobs
{
    public class SampleJob:IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            var msg = String.Format("***** IN SAMPLE JOB...Value Sent: {0}", dataMap["Param1"].ToString()); 
            Console.WriteLine(msg);
        }
    }
}
