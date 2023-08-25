using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace My_WindowsService
{
    public partial class Service : ServiceBase
    {
        Timer timer = new Timer();
        public const string _path = "C:/Users/Moon/Desktop/ASM";


        public Service()
        {
            InitializeComponent();
        }


        //internal void TestStartupAndStop(string[] args)
        //{
        //    OnStart(args);
        //    Console.ReadLine();
        //    OnStop();
        //}
        protected override void OnStart(string[] args)
        {
            //timeDelay = new System.Timers.Timer(15000);
            timer = new Timer(5000);
            //timer.Interval = 10000; //the timer.Elapsed event is triggered when the interval (5sec) of the timer has passed
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        public void AppServiceEntry()
        {
            ASMReader.ReadFile(_path);

        }

        private void OnElapsedTime(object source,ElapsedEventArgs e)
        {
            //OnStart()
            ASMReader.ReadFile(_path);
        }
    }
}
