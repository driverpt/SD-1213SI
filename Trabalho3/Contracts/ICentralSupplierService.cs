namespace Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using Contracts.Types;

    // For Testing Purposes
    [ServiceContract]
    public interface IBaseCentralSupplierService
    {
        [OperationContract(IsOneWay = false)]
        List<ProductFamily> GetSupplierProductFamilies(string supplierName);
    }

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IProductosServiceCentral))]
    public interface ICentralSupplierService
    {
        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(CentralServiceFault))]
        bool RegisterSupplier();

        [OperationContract(IsOneWay = false)]
        [FaultContract(typeof(CentralServiceFault))]
        bool UnregisterSupplier(string supplierName);
    }

    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IComprasServiceCentral))]
    public interface ICentralOrganizationService
    {
        [OperationContract]
        [FaultContract(typeof(CentralServiceFault))]
        ContestInfoWithSuppliers CreateContest(string endPoint, Product product);

        [OperationContract]
        List<Supplier> GetPossibleSuppliers(int proposalId);
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICentralServiceForDualCommunication
    {
        [OperationContract(IsInitiating = true)]
        void SignIn();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void SignOut();
    }
}