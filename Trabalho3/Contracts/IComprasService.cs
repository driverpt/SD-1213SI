namespace Contracts
{
    using System.ServiceModel;

    using DomainLayer.Types;

    [ServiceContract]
    public interface IComprasService
    {
        [OperationContract]
        void PostProposal(int contestId, Product product, double price);
    }
}