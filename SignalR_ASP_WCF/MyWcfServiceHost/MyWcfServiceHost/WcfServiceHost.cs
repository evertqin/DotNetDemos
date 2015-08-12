using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading;

namespace MyWcfServiceHost
{
    internal class WcfServiceHost : ServiceBase
    {
        private static readonly Dictionary<string, ServiceHost> _ServiceHosts = new Dictionary<string, ServiceHost>();

        public static ServiceHost GetService(string sSrvName)
        {
            if (_ServiceHosts.ContainsKey(sSrvName)) return _ServiceHosts[sSrvName];
            return null;
        }

        public WcfServiceHost()
        {
            this.ServiceName = "MyWcfService";
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }

        private static void RunInteractive(ServiceBase[] servicesToRun)
        {
            Console.WriteLine("Services running in interactive mode.");
            Console.WriteLine();

            MethodInfo onStartMethod = typeof (ServiceBase).GetMethod("OnStart",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Starting {0}...", service.ServiceName);
                ((WcfServiceHost) service).OnStart(new string[] {});
                //onStartMethod.Invoke(service, new object[] { new string[] { } });
                Console.Write("Started");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(
                "Press any key to stop the services and end the process...");
            Console.ReadKey();
            Console.WriteLine();

            MethodInfo onStopMethod = typeof (ServiceBase).GetMethod("OnStop",
                BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (ServiceBase service in servicesToRun)
            {
                Console.Write("Stopping {0}...", service.ServiceName);
                //onStopMethod.Invoke(service, null);
                ((WcfServiceHost) service).OnStop();
                Console.WriteLine("Stopped");
            }

            Console.WriteLine("All services stopped.");
            // Keep the console alive for a second to allow the user to see the message.
            Thread.Sleep(1000);
        }

        protected int OpenAll()
        {
            OpenHost<MyWcfService>();
            return _ServiceHosts.Count();
        }

        protected int CloseAll()
        {
            foreach (ServiceHost serviceHost in _ServiceHosts.Values)
            {
                try
                {
                    serviceHost.Close(new TimeSpan(0, 0, 10));
                }
                catch (Exception ex)
                {
                    serviceHost.Abort();
                }
            }
            _ServiceHosts.Clear();
            return 0;
        }

        protected void OpenHost<T>()
        {
            Type type = typeof (T);
            ServiceHost serviceHost = new ServiceHost(type);
            serviceHost.Open();
            _ServiceHosts[type.ToString()] = serviceHost;
        }

        protected override void OnStart(string[] args)
        {
            // eventlog.WriteEntry("AnalysisWindowsService started.");
            this.CloseAll();
            this.OpenAll();
        }

        protected override void OnStop()
        {
            this.CloseAll();
        }

        private static void Main(string[] args)
        {
            ServiceBase[] servicesToRun;
            servicesToRun = new ServiceBase[]
            {
                new WcfServiceHost()
            };
            if (Environment.UserInteractive)
            {
                RunInteractive(servicesToRun);
            }
            else
            {
                Run(servicesToRun);
            }
        }
    }
}
