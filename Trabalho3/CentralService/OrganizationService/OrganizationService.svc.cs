using System.Collections.Generic;
using System.ServiceModel;

namespace OrganizationService
{
    using Contracts;
    using Contracts.Types;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrganizationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrganizationService.svc or OrganizationService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class OrganizationService : IComprasService, IComprasServiceCentral
    {
        private static IDictionary<int, List<Proposal>> Proposals = new Dictionary<int, List<Proposal>>(); 

        public void PostProposal(int contestId, Product product, Supplier supplier)
        {
            List<Proposal> prop;
            if (!Proposals.ContainsKey(contestId))
            {
                prop = new List<Proposal>();
                Proposals.Add(contestId, prop);
            }
            else
            {
                prop = Proposals[contestId];
            }
            Proposal proposal = new Proposal { Product = product, Supplier = supplier };
            prop.Add(proposal);
        }

        public Organization GetOrganizationInfo()
        {
            return new Organization { EndPoint = OperationContext.Current.Channel.LocalAddress.ToString(), Name = "Organization 1"};
        }
    }

    public class Proposal
    {
        public Product Product { get; set; }
        public Supplier Supplier { get; set; }
    }
}
