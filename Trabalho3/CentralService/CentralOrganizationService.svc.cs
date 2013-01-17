using System.Collections.Generic;

namespace CentralService
{
    using System.ServiceModel;

    using Contracts;

    using DomainLayer.Service;
    using DomainLayer.Types;

    using Ninject;

    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CentralOrganizationService : ICentralOrganizationService
    {
        [Inject]
        private ContestService _contestService; 

        public void SignIn()
        {
            
        }

        public void SignOut()
        {
            
        }

        public int CreateContest(string endPoint, Product product)
        {
            throw new System.NotImplementedException();
        }

        public List<Supplier> GetPossibleSuppliers(int proposalId)
        {
            throw new System.NotImplementedException();
        }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CentralSupplierService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CentralSupplierService.svc or CentralSupplierService.svc.cs at the Solution Explorer and start debugging.
}
