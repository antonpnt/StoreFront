﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Week3Assignment.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchProducts", ReplyAction="http://tempuri.org/IService1/SearchProductsResponse")]
        StoreFront.Data.Product[] SearchProducts(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchProducts", ReplyAction="http://tempuri.org/IService1/SearchProductsResponse")]
        System.Threading.Tasks.Task<StoreFront.Data.Product[]> SearchProductsAsync(string text);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetProductDetails", ReplyAction="http://tempuri.org/IService1/GetProductDetailsResponse")]
        StoreFront.Data.Product GetProductDetails(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetProductDetails", ReplyAction="http://tempuri.org/IService1/GetProductDetailsResponse")]
        System.Threading.Tasks.Task<StoreFront.Data.Product> GetProductDetailsAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Week3Assignment.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Week3Assignment.ServiceReference1.IService1>, Week3Assignment.ServiceReference1.IService1 {
        
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
        
        public StoreFront.Data.Product[] SearchProducts(string text) {
            return base.Channel.SearchProducts(text);
        }
        
        public System.Threading.Tasks.Task<StoreFront.Data.Product[]> SearchProductsAsync(string text) {
            return base.Channel.SearchProductsAsync(text);
        }
        
        public StoreFront.Data.Product GetProductDetails(int id) {
            return base.Channel.GetProductDetails(id);
        }
        
        public System.Threading.Tasks.Task<StoreFront.Data.Product> GetProductDetailsAsync(int id) {
            return base.Channel.GetProductDetailsAsync(id);
        }
    }
}
