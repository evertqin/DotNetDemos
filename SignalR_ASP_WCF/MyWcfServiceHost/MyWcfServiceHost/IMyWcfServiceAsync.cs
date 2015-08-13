using System.ServiceModel;

namespace MyWcfServiceHost
{

    [ServiceContract(Namespace = "mynamspace", SessionMode = SessionMode.Required)]
    public interface IClientCallback
    {
        [OperationContract]
        void NotifyClient(string message);
    }

    [ServiceContract(Namespace = "mynamspace", SessionMode = SessionMode.Required,
        CallbackContract = typeof (IClientCallback))]
    public interface IMyWcfServiceAsync
    {
        [OperationContract(IsOneWay = true)]
        void ListenToEvents();
    }
}
