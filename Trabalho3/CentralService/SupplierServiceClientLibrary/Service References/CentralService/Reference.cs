﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupplierServiceClientLibrary.CentralService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CentralService.ICentralSupplierService", CallbackContract=typeof(SupplierServiceClientLibrary.CentralService.ICentralSupplierServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ICentralSupplierService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralServiceForDualCommunication/SignIn", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignInResponse")]
        void SignIn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralServiceForDualCommunication/SignIn", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignInResponse")]
        System.Threading.Tasks.Task SignInAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICentralServiceForDualCommunication/SignOut", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignOutResponse")]
        void SignOut();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICentralServiceForDualCommunication/SignOut", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignOutResponse")]
        System.Threading.Tasks.Task SignOutAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralSupplierService/RegisterSupplier", ReplyAction="http://tempuri.org/ICentralSupplierService/RegisterSupplierResponse")]
        bool RegisterSupplier(Contracts.Types.Supplier supplier);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralSupplierService/RegisterSupplier", ReplyAction="http://tempuri.org/ICentralSupplierService/RegisterSupplierResponse")]
        System.Threading.Tasks.Task<bool> RegisterSupplierAsync(Contracts.Types.Supplier supplier);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralSupplierService/UnregisterSupplier", ReplyAction="http://tempuri.org/ICentralSupplierService/UnregisterSupplierResponse")]
        bool UnregisterSupplier(string supplierName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralSupplierService/UnregisterSupplier", ReplyAction="http://tempuri.org/ICentralSupplierService/UnregisterSupplierResponse")]
        System.Threading.Tasks.Task<bool> UnregisterSupplierAsync(string supplierName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICentralSupplierServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralSupplierService/GetSupplierInfo", ReplyAction="http://tempuri.org/ICentralSupplierService/GetSupplierInfoResponse")]
        Contracts.Types.Supplier GetSupplierInfo();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICentralSupplierService/NewContest")]
        void NewContest(Contracts.Types.ContestInfo contest);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICentralSupplierServiceChannel : SupplierServiceClientLibrary.CentralService.ICentralSupplierService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CentralSupplierServiceClient : System.ServiceModel.DuplexClientBase<SupplierServiceClientLibrary.CentralService.ICentralSupplierService>, SupplierServiceClientLibrary.CentralService.ICentralSupplierService {
        
        public CentralSupplierServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CentralSupplierServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CentralSupplierServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CentralSupplierServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CentralSupplierServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SignIn() {
            base.Channel.SignIn();
        }
        
        public System.Threading.Tasks.Task SignInAsync() {
            return base.Channel.SignInAsync();
        }
        
        public void SignOut() {
            base.Channel.SignOut();
        }
        
        public System.Threading.Tasks.Task SignOutAsync() {
            return base.Channel.SignOutAsync();
        }
        
        public bool RegisterSupplier(Contracts.Types.Supplier supplier) {
            return base.Channel.RegisterSupplier(supplier);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterSupplierAsync(Contracts.Types.Supplier supplier) {
            return base.Channel.RegisterSupplierAsync(supplier);
        }
        
        public bool UnregisterSupplier(string supplierName) {
            return base.Channel.UnregisterSupplier(supplierName);
        }
        
        public System.Threading.Tasks.Task<bool> UnregisterSupplierAsync(string supplierName) {
            return base.Channel.UnregisterSupplierAsync(supplierName);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CentralService.ICentralOrganizationService", CallbackContract=typeof(SupplierServiceClientLibrary.CentralService.ICentralOrganizationServiceCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface ICentralOrganizationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralServiceForDualCommunication/SignIn", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignInResponse")]
        void SignIn();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralServiceForDualCommunication/SignIn", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignInResponse")]
        System.Threading.Tasks.Task SignInAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICentralServiceForDualCommunication/SignOut", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignOutResponse")]
        void SignOut();
        
        [System.ServiceModel.OperationContractAttribute(IsTerminating=true, IsInitiating=false, Action="http://tempuri.org/ICentralServiceForDualCommunication/SignOut", ReplyAction="http://tempuri.org/ICentralServiceForDualCommunication/SignOutResponse")]
        System.Threading.Tasks.Task SignOutAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralOrganizationService/CreateContest", ReplyAction="http://tempuri.org/ICentralOrganizationService/CreateContestResponse")]
        int CreateContest(string endPoint, Contracts.Types.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralOrganizationService/CreateContest", ReplyAction="http://tempuri.org/ICentralOrganizationService/CreateContestResponse")]
        System.Threading.Tasks.Task<int> CreateContestAsync(string endPoint, Contracts.Types.Product product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralOrganizationService/GetPossibleSuppliers", ReplyAction="http://tempuri.org/ICentralOrganizationService/GetPossibleSuppliersResponse")]
        Contracts.Types.Supplier[] GetPossibleSuppliers(int proposalId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralOrganizationService/GetPossibleSuppliers", ReplyAction="http://tempuri.org/ICentralOrganizationService/GetPossibleSuppliersResponse")]
        System.Threading.Tasks.Task<Contracts.Types.Supplier[]> GetPossibleSuppliersAsync(int proposalId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICentralOrganizationServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICentralOrganizationService/GetOrganizationInfo", ReplyAction="http://tempuri.org/ICentralOrganizationService/GetOrganizationInfoResponse")]
        Contracts.Types.Organization GetOrganizationInfo();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICentralOrganizationServiceChannel : SupplierServiceClientLibrary.CentralService.ICentralOrganizationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CentralOrganizationServiceClient : System.ServiceModel.DuplexClientBase<SupplierServiceClientLibrary.CentralService.ICentralOrganizationService>, SupplierServiceClientLibrary.CentralService.ICentralOrganizationService {
        
        public CentralOrganizationServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CentralOrganizationServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CentralOrganizationServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CentralOrganizationServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CentralOrganizationServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SignIn() {
            base.Channel.SignIn();
        }
        
        public System.Threading.Tasks.Task SignInAsync() {
            return base.Channel.SignInAsync();
        }
        
        public void SignOut() {
            base.Channel.SignOut();
        }
        
        public System.Threading.Tasks.Task SignOutAsync() {
            return base.Channel.SignOutAsync();
        }
        
        public int CreateContest(string endPoint, Contracts.Types.Product product) {
            return base.Channel.CreateContest(endPoint, product);
        }
        
        public System.Threading.Tasks.Task<int> CreateContestAsync(string endPoint, Contracts.Types.Product product) {
            return base.Channel.CreateContestAsync(endPoint, product);
        }
        
        public Contracts.Types.Supplier[] GetPossibleSuppliers(int proposalId) {
            return base.Channel.GetPossibleSuppliers(proposalId);
        }
        
        public System.Threading.Tasks.Task<Contracts.Types.Supplier[]> GetPossibleSuppliersAsync(int proposalId) {
            return base.Channel.GetPossibleSuppliersAsync(proposalId);
        }
    }
}
