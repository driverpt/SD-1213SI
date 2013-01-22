namespace OrganizationClientLibrary
{
    using System;

    namespace SupplierServiceClientLibrary
    {
        using Contracts;

        using Organization = Contracts.Types.Organization;
        using Product = Contracts.Types.Product;

        public class OrganizationCallback : IComprasService
        {
            public void PostProposal(int contestId, Product product, double price)
            {
                throw new NotImplementedException();
            }

            public Organization GetOrganizationInfo()
            {
                return new Organization { EndPoint = "http://localhost", Name = "Organization 1" };
            }
        }
    }

}
