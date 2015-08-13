using Donah.BackgroundWorkerPrj.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Donah.BackgroundWorkerPrj.WindowsForms
{
    public partial class Form1 : Form
    {
        private ThreadController ThreadController = null;
        private BackgroundWorker Thread1 = null;
        private BackgroundWorker Thread2 = null;

        public Form1()
        {
            InitializeComponent();

            ThreadController = new ThreadController();

            StartThread1();
        }

        private void StartThread1()
        {
            Thread1 = new BackgroundWorker();
            Thread1.DoWork += new DoWorkEventHandler(Thread1_DoWork);
            Thread1.ProgressChanged += new ProgressChangedEventHandler(Thread1_ProgressChanged);
            Thread1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Thread1_RunWorkerCompleted);
            Thread1.WorkerReportsProgress = true;
            Thread1.WorkerSupportsCancellation = true;

            Thread1.RunWorkerAsync();
            ThreadController.ThreadOne.StartThread();
        }

        private void StartThread2()
        {
            Thread2 = new BackgroundWorker();
            Thread2.DoWork += new DoWorkEventHandler(Thread2_DoWork);
            Thread2.ProgressChanged += new ProgressChangedEventHandler(Thread2_ProgressChanged);
            Thread2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Thread2_RunWorkerCompleted);
            Thread2.WorkerReportsProgress = true;
            Thread2.WorkerSupportsCancellation = true;

            Thread2.RunWorkerAsync();
            ThreadController.ThreadTwo.StartThread();
        }

        #region THREAD 1

        void Thread1_DoWork(object sender, DoWorkEventArgs e)
        {
            //IF E.ARGUMENT IS TRUE, THEN IT SHOULD WAIT (SEE Thread1_RunWorkerCompleted)
            if (e.Argument != null && Convert.ToBoolean(e.Argument))
            {
                Thread.Sleep(2000);
            }

            int count = 0;
            do
            {
                //SET STATUS
                ThreadController.ThreadOne.SetThreadExecuting();

                //DO MAIN WORK HERE
                for (int i = 0; i < 11; i++)
                {
                    //YOU CAN SEND ANY OBJECT HERE FOR THE PROGRESS 
                    Thread1.ReportProgress(i, true);
                    //TIMEOUT
                    Thread.Sleep(500);
                }

                //SIMULATING A BREAKING CONDITION FOR THE MAIN WORK
                if (count >= 1)
                {
                    break;
                }

                count++;

                //UPDATE STATUS (FALSE FOR "THREAD IS SLEEPING")
                Thread1.ReportProgress(0, false);

                //THE MAIN WORK HAS ENDED, PUT THE THREAD TO "SLEEP"
                ThreadController.ThreadOne.SetThreadWaiting();
                Thread.Sleep(2000);
            } while (true);
        }

        private void Thread1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToBoolean(e.UserState))
            {
                lblThread1Status.Text = "Thread 1 Status: Executing (" + e.ProgressPercentage.ToString() + ")";
            }
            else
            {
                lblThread1Status.Text = "Thread 1 Status: SLEEPING";
            }
        }

        private void Thread1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ThreadController.ThreadOne.StopThread();
            lblThread1Status.Text = "Thread 1 Status: DEAD";

            //CALL IT AGAIN, BUT TELLS IT TO WAIT
            Thread1.RunWorkerAsync(true);
        }

        private void Thread1_TickRestart(object sender, ElapsedEventArgs e)
        {
            Thread1.RunWorkerAsync();
        }

        #endregion

        #region THREAD 2

        void Thread2_DoWork(object sender, DoWorkEventArgs e)
        {
            //SET STATUS
            ThreadController.ThreadTwo.SetThreadExecuting();

            //DO MAIN WORK HERE
            for (int i = 0; i < 11; i++)
            {
                //YOU CAN SEND ANY OBJECT HERE FOR THE PROGRESS 
                Thread2.ReportProgress(i, true);
                //TIMEOUT
                Thread.Sleep(500);
            }
        }

        private void Thread2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Convert.ToBoolean(e.UserState))
            {
                lblThread2Status.Text = "Thread 2 Status: Executing (" + e.ProgressPercentage.ToString() + ")";
            }
            else
            {
                lblThread2Status.Text = "Thread 2 Status: SLEEPING";
            }
        }

        private void Thread2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ThreadController.ThreadTwo.StopThread();
            lblThread2Status.Text = "Thread 2 Status: DEAD";
        }

        #endregion

        private void btnForceThread2_Click(object sender, EventArgs e)
        {
            if (ThreadController.ThreadOne.IsExecuting)
            {
                MessageBox.Show("You can't start this operation while thread 1 is executing!");
            }
            else if(ThreadController.ThreadTwo.IsExecuting)
            {
                MessageBox.Show("You can't repeat this operation. Thread 2 is already executing!");
            }
            else
            {
                //MessageBox.Show("YES U CAN");
                StartThread2();
            }
        }
    }
}
