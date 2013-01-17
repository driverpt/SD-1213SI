namespace Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using DomainLayer.Types;

    [ServiceContract]
    public interface IBaseCentralSupplierService
    {
        [OperationContract(IsOneWay = false)]
        List<ProductFamily> GetSupplierProductFamilies(string supplierName);
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICentralSupplierService : ICentralServiceForDualCommunication
    {
        [OperationContract(IsOneWay = false)]
        bool RegisterSupplier(Supplier supplier);

        [OperationContract(IsOneWay = false)]
        bool UnregisterSupplier(string supplierName);
    }

    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ICentralOrganizationService : ICentralServiceForDualCommunication
    {
        [OperationContract]
        int CreateContest(string endPoint, Product product);

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