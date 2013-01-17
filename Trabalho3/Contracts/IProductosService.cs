namespace Contracts
{
    using System.ServiceModel;

    using DomainLayer.Types;

    [ServiceContract]
    public interface IProductosService
    {
        /// <summary>
        /// This method is to be called by the Central Service to notify when a new Contest is created
        /// </summary>
        /// <param name="contestId">
        /// The contest id.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        [OperationContract]
        void NewProposal(int contestId, Product product);

        /// <summary>
        /// This method is to be used by the organization to accept the proposal.
        /// </summary>
        /// <param name="contestId">
        /// The contest id.
        /// </param>
        [OperationContract]
        void AcceptProposal(int contestId);

        /// <summary>
        /// This method is to be used by the organization to reject the proposal.
        /// </summary>
        /// <param name="contextId">
        /// The context id.
        /// </param>
        [OperationContract]
        void RejectProposal(int contextId);
    }
}