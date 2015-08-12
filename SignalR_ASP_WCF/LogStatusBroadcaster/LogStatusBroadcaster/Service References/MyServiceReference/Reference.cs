﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogStatusBroadcaster.MyServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyServiceReference.IMyWcfService")]
    public interface IMyWcfService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyWcfService/DoWork", ReplyAction="http://tempuri.org/IMyWcfService/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyWcfService/DoWork", ReplyAction="http://tempuri.org/IMyWcfService/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyWcfServiceChannel : LogStatusBroadcaster.MyServiceReference.IMyWcfService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWcfServiceClient : System.ServiceModel.ClientBase<LogStatusBroadcaster.MyServiceReference.IMyWcfService>, LogStatusBroadcaster.MyServiceReference.IMyWcfService {
        
        public MyWcfServiceClient() {
        }
        
        public MyWcfServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyWcfServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWcfServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyWcfServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="mynamspace", ConfigurationName="MyServiceReference.IMyWcfServiceAsync", CallbackContract=typeof(LogStatusBroadcaster.MyServiceReference.IMyWcfServiceAsyncCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IMyWcfServiceAsync {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="mynamspace/IMyWcfServiceAsync/ListenToEvents")]
        void ListenToEvents();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="mynamspace/IMyWcfServiceAsync/ListenToEvents")]
        System.Threading.Tasks.Task ListenToEventsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyWcfServiceAsyncCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="mynamspace/IMyWcfServiceAsync/NotifyClient", ReplyAction="mynamspace/IMyWcfServiceAsync/NotifyClientResponse")]
        void NotifyClient(string message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyWcfServiceAsyncChannel : LogStatusBroadcaster.MyServiceReference.IMyWcfServiceAsync, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyWcfServiceAsyncClient : System.ServiceModel.DuplexClientBase<LogStatusBroadcaster.MyServiceReference.IMyWcfServiceAsync>, LogStatusBroadcaster.MyServiceReference.IMyWcfServiceAsync {
        
        public MyWcfServiceAsyncClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public MyWcfServiceAsyncClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public MyWcfServiceAsyncClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MyWcfServiceAsyncClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public MyWcfServiceAsyncClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ListenToEvents() {
            base.Channel.ListenToEvents();
        }
        
        public System.Threading.Tasks.Task ListenToEventsAsync() {
            return base.Channel.ListenToEventsAsync();
        }
    }
}