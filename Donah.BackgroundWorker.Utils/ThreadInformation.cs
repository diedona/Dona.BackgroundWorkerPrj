using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donah.BackgroundWorkerPrj.Utils
{
    public class ThreadInformation
    {
        public bool IsExecuting { get; private set; }
        public DateTime? StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }

        public ThreadInformation()
        {
            IsExecuting = false;
            StartTime = null;
            EndTime = null;
        }

        public void StartThread()
        {
            IsExecuting = true;
            StartTime = DateTime.Now;
            EndTime = null;
        }

        public void SetThreadWaiting()
        {
            IsExecuting = false;
        }

        public void SetThreadExecuting()
        {
            IsExecuting = true;
        }

        public void StopThread()
        {
            IsExecuting = false;
            EndTime = DateTime.Now;
        }
    }
}
