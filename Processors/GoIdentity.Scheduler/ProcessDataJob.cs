using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoIdentity.Scheduler
{
    public class ProcessDataJob : IJob
    {
        private static bool IsRunning = default(bool);

        public Task Execute(IJobExecutionContext context)
        {
            if (IsRunning) return default(Task);
            IsRunning = true;

            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                IsRunning = false;
            }

            return default(Task);
        }
    }
}
