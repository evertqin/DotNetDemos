using System.ServiceModel;

namespace MyWcfServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyWcfService" in both code and config file together.
    [ServiceContract]
    public interface IMyWcfService
    {
        [OperationContract]
        void DoWork();
    }
}
