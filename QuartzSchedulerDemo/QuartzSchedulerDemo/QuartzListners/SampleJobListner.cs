using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace QuartzSchedulerDemo.QuartzListners
{
    public class SampleJobListner : IJobListener
    {
        
        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            Console.WriteLine("In Job Execution Vetoed");
        }

        public void JobToBeExecuted(IJobExecutionContext context)
        {
            Console.WriteLine("In Job To Be Executed");
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            Console.WriteLine("In Job Was Executed");
        }

        public string Name { get {return "SampleJobListner"; } }

        
    }
}
