﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentralService.ProductsService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductsService.IProductosService")]
    public interface IProductosService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IProductosService/AcceptProposal")]
        void AcceptProposal(int contestId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IProductosService/RejectProposal")]
        void RejectProposal(int contextId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductosServiceChannel : ProductsService.IProductosService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductosServiceClient : System.ServiceModel.ClientBase<ProductsService.IProductosService>, ProductsService.IProductosService {
        
        public ProductosServiceClient() {
        }
        
        public ProductosServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductosServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AcceptProposal(int contestId) {
            base.Channel.AcceptProposal(contestId);
        }
        
        public void RejectProposal(int contextId) {
            base.Channel.RejectProposal(contextId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductsService.IProductosServiceCentral")]
    public interface IProductosServiceCentral {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductosServiceCentral/GetSupplierInfo", ReplyAction="http://tempuri.org/IProductosServiceCentral/GetSupplierInfoResponse")]
        Contracts.Types.Supplier GetSupplierInfo();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IProductosServiceCentral/NewContest")]
        void NewContest(Contracts.Types.ContestInfo contest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductosServiceCentralChannel : ProductsService.IProductosServiceCentral, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductosServiceCentralClient : System.ServiceModel.ClientBase<ProductsService.IProductosServiceCentral>, ProductsService.IProductosServiceCentral {
        
        public ProductosServiceCentralClient() {
        }
        
        public ProductosServiceCentralClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductosServiceCentralClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosServiceCentralClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductosServiceCentralClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Contracts.Types.Supplier GetSupplierInfo() {
            return base.Channel.GetSupplierInfo();
        }
        
        public void NewContest(Contracts.Types.ContestInfo contest) {
            base.Channel.NewContest(contest);
        }
    }
}