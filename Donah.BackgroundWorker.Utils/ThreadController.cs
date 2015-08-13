using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donah.BackgroundWorkerPrj.Utils
{
    public class ThreadController
    {
        public ThreadInformation ThreadOne { get; set; }
        public ThreadInformation ThreadTwo { get; set; }

        public ThreadController()
        {
            ThreadOne = new ThreadInformation();
            ThreadTwo = new ThreadInformation();
        }
    }
}
