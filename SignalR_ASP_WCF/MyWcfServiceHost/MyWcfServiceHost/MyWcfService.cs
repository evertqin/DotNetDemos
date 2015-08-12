using System.ServiceModel;
using LogBroadcaster.Broadcast;
using LogBroadcaster.Test;

namespace MyWcfServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyWcfService" in both code and config file together.
    public class MyWcfService : IMyWcfService, IMyWcfServiceAsync
    {
        public void DoWork()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.GeneratingRandomLog();
        }

        public void ListenToEvents()
        {
            // this call back is only valid in the context of this function
            var callback = OperationContext.Current.GetCallbackChannel<IClientCallback>();

            BroadcastEventService.Instance.BroadcastEvent +=
                (sender, eventArgs) => { callback.NotifyClient(eventArgs.Message); };
        }
    }
}
