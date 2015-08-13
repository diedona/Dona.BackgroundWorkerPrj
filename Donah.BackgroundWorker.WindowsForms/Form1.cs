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
        private ThreadController Thread1Controller = null;
        private ThreadController Thread2Controller = null;
        private BackgroundWorker Thread1 = null;
        private BackgroundWorker Thread2 = null;

        public Form1()
        {
            InitializeComponent();

            Thread1Controller = new ThreadController();
            Thread2Controller = new ThreadController();

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
            Thread1Controller.ThreadOne.StartThread();
        }

        #region THREAD 1
        void Thread1_DoWork(object sender, DoWorkEventArgs e)
        {
            //IF E.ARGUMENT IS TRUE, THEN IT SHOULD WAIT (SEE Thread1_RunWorkerCompleted)
            if(e.Argument != null && Convert.ToBoolean(e.Argument))
            {
                Thread.Sleep(2000);
            }
            
            int count = 0;
            do
            {
                //SET STATUS
                Thread1Controller.ThreadOne.SetThreadWaiting();

                //DO MAIN WORK HERE
                for(int i = 0; i < 11; i++)
                {
                    //YOU CAN SEND ANY OBJECT HERE FOR THE PROGRESS 
                    Thread1.ReportProgress(i, true);
                    //TIMEOUT
                    Thread.Sleep(500);
                }

                //SIMULATING A BREAKING CONDITION FOR THE MAIN WORK
                if(count >= 1)
                {
                    break;
                }

                count++;

                //UPDATE STATUS (FALSE FOR "THREAD IS SLEEPING")
                Thread1.ReportProgress(0, false);

                //THE MAIN WORK HAS ENDED, PUT THE THREAD TO "SLEEP"
                Thread1Controller.ThreadOne.SetThreadWaiting();
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
            Thread1Controller.ThreadOne.StopThread();
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

        }
        private void Thread2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        private void Thread2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        } 
        #endregion

        private void btnForceThread2_Click(object sender, EventArgs e)
        {

        }
    }
}
