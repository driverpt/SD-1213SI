namespace DomainLayer.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using DomainLayer.Interfaces;
    using DomainLayer.Types;

    using Ninject;

    /// <summary>
    /// The contest service.
    /// </summary>
    public class ContestService
    {
        [Inject]
        private IRepository<ContestInfo, int> _contestInfos;

        [Inject]
        private SuppliersService _suppliersService;

        public ContestInfo CreateContest(Organization org, Product product)
        {
            ContestInfo contestInfo = new ContestInfo { Product = product, Organization = org };
            _contestInfos.Add(contestInfo);
            return contestInfo;
        } 

        public ContestInfo GetById(int id)
        {
            return _contestInfos.GetById(id);
        }

        public IEnumerable<Supplier> GetCandidatesForContest(int contestId)
        {
            IEnumerable<Supplier> suppliers = _suppliersService.GetAll();
            ContestInfo contestInfo = _contestInfos.GetById(contestId);
            var matchedSuppliers = suppliers.Where(supplier => supplier.Products.Contains(contestInfo.Product) );
            return matchedSuppliers;
        }
    }
}