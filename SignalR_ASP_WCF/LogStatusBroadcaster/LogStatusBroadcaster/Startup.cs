using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using LogStatusBroadcaster.MyServiceReference;

[assembly: OwinStartup(typeof(LogStatusBroadcaster.Startup))]

namespace LogStatusBroadcaster
{
    public class Startup
    {
        private string DEFAULT_TCP_BINDING_ENDPOINT_NAME = "NetTcpBinding_IMyWcfService";
        private string DEFAULT_TCP_ASYNC_BINDING_ENDPOINT_NAME = "NetTcpBinding_IMyWcfServiceAsync";

        private MyWcfServiceClient _mywcfServiceClient;
        private MyWcfServiceAsyncClient _myWcfServiceAsyncClient;
        private StatusUpdateHandlerHub _statusUpdateHanderHub;


        public MyWcfServiceClient MyWcfServiceClient
        {
            get
            {
                if (_mywcfServiceClient == null)
                {
                    _mywcfServiceClient = new MyWcfServiceClient(DEFAULT_TCP_BINDING_ENDPOINT_NAME);
                }

                if (_mywcfServiceClient.State == System.ServiceModel.CommunicationState.Closed)
                {
                    _mywcfServiceClient.Open();
                }
                return _mywcfServiceClient;
            }
        }

        public MyWcfServiceAsyncClient MyWcfServiceAsyncClient
        {
            get
            {
                if (_myWcfServiceAsyncClient == null)
                {
                    InstanceContext instanceContext = new InstanceContext(StatusUpdateHandlerHub);
                    _myWcfServiceAsyncClient = new MyWcfServiceAsyncClient(instanceContext);
                }

                if (_myWcfServiceAsyncClient.State == CommunicationState.Closed)
                {
                    _myWcfServiceAsyncClient.Open();
                }

                return _myWcfServiceAsyncClient;
            }
        }

        public StatusUpdateHandlerHub StatusUpdateHandlerHub
        {
            get { return _statusUpdateHanderHub ?? (_statusUpdateHanderHub = new StatusUpdateHandlerHub()); }
        }


        public void Configuration(IAppBuilder app)
        {
            
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
            MyWcfServiceAsyncClient.ListenToEvents();

            MyWcfServiceClient.DoWork();

        }
    }
}
