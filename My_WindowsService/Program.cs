using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace My_WindowsService
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)


        {


            #if DEBUG
                        //While debugging this section is used.
                        Service myService = new Service();
                        myService.OnDebug();
                        Thread.Sleep(Timeout.Infinite);

            #else
                            //In Release this section is used. This is the "normal" way.
                            ServiceBase[] ServicesToRun;
                            ServicesToRun = new ServiceBase[] 
                            { 
                                new Service() 
                            };
                            ServiceBase.Run(ServicesToRun);
            #endif


        }

    }
}
