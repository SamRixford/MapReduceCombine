﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSE446Assignment6.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/map", ReplyAction="http://tempuri.org/IService1/mapResponse")]
        System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> map(System.Collections.Generic.List<string> textDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/map", ReplyAction="http://tempuri.org/IService1/mapResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>>> mapAsync(System.Collections.Generic.List<string> textDoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/reduce", ReplyAction="http://tempuri.org/IService1/reduceResponse")]
        System.Collections.Generic.Dictionary<string, int> reduce(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> values);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/reduce", ReplyAction="http://tempuri.org/IService1/reduceResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> reduceAsync(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> values);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/combine", ReplyAction="http://tempuri.org/IService1/combineResponse")]
        System.Collections.Generic.Dictionary<string, int> combine(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> toCombine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/combine", ReplyAction="http://tempuri.org/IService1/combineResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> combineAsync(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> toCombine);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : CSE446Assignment6.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<CSE446Assignment6.ServiceReference1.IService1>, CSE446Assignment6.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> map(System.Collections.Generic.List<string> textDoc) {
            return base.Channel.map(textDoc);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>>> mapAsync(System.Collections.Generic.List<string> textDoc) {
            return base.Channel.mapAsync(textDoc);
        }
        
        public System.Collections.Generic.Dictionary<string, int> reduce(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> values) {
            return base.Channel.reduce(values);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> reduceAsync(System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, int>> values) {
            return base.Channel.reduceAsync(values);
        }
        
        public System.Collections.Generic.Dictionary<string, int> combine(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> toCombine) {
            return base.Channel.combine(toCombine);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, int>> combineAsync(System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, int>> toCombine) {
            return base.Channel.combineAsync(toCombine);
        }
    }
}