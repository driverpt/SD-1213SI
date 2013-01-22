namespace Contracts
{
    using System.ServiceModel;

    using Contracts.Types;

    [ServiceContract]
    public interface IComprasService
    {
        [OperationContract(IsOneWay = true)]
        void PostProposal(int contestId, Product product, Supplier supplier);
    }

    [ServiceContract]
    public interface IComprasServiceCentral
    {
        [OperationContract]
        Organization GetOrganizationInfo();
    }
}