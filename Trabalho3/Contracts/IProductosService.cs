namespace Contracts
{
    using System.ServiceModel;

    using Contracts.Types;

    [ServiceContract]
    public interface IProductosService
    {
        /// <summary>
        /// This method is to be used by the organization to accept the proposal.
        /// </summary>
        /// <param name="contestId">
        /// The contest id.
        /// </param>
        [OperationContract(IsOneWay = true)]
        void AcceptProposal(int contestId);

        /// <summary>
        /// This method is to be used by the organization to reject the proposal.
        /// </summary>
        /// <param name="contextId">
        /// The context id.
        /// </param>
        [OperationContract(IsOneWay = true)]
        void RejectProposal(int contextId);
    }

    [ServiceContract]
    public interface IProductosServiceCentral
    {
        /// <summary>
        /// The get supplier info.
        /// </summary>
        /// <returns>
        /// The <see cref="Supplier"/>.
        /// </returns>
        [OperationContract]
        Supplier GetSupplierInfo();

        /// <summary>
        /// This method is to be called by the Central Service to notify when a new Contest is created
        /// </summary>
        /// <param name="contestId">
        /// The contest id.
        /// </param>
        /// <param name="product">
        /// The product.
        /// </param>
        [OperationContract(IsOneWay = true)]
        void NewContest(ContestInfo contest);

    }
}