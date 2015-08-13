using System.ServiceModel;
using LogStatusBroadcaster.MyServiceReference;
using Microsoft.AspNet.SignalR;


namespace LogStatusBroadcaster
{
    public delegate void BroadcastEventhander(object sender, string message);


    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class StatusUpdateHandlerHub : Hub, IMyWcfServiceAsyncCallback
    {
        public static event BroadcastEventhander BroadcastEvent;

        public void ListenToStatus()
        {
            if (BroadcastEvent == null)
            {
                BroadcastEvent += (sender, message) => { Clients.All.listenToStatus(message); };
            }
        }

        public void NotifyClient(string message)
        {
            if (BroadcastEvent != null)
            {
                BroadcastEvent(this, message);
            }
        }
    }
}