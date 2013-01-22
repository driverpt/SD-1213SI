using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    using System.Threading.Tasks;

    using Contracts;
    using Contracts.Types;

    using global::CentralService.ProductsService;

    using IProductosService = Contracts.IProductosService;
    using IProductosServiceCentral = Contracts.IProductosServiceCentral;

    /// <summary>
    /// The central service.
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CentralService : ICentralSupplierService, ICentralOrganizationService, ICentralServiceForDualCommunication
    {
        private readonly object _monitor = new object();
        private static IDictionary<string, Supplier> _suppliers;

        private static IDictionary<int, ContestInfo> _contestInfos;

        public CentralService()
        {
            _suppliers = new Dictionary<string, Supplier>();
            _contestInfos = new Dictionary<int, ContestInfo>();
        }

        public bool RegisterSupplier()
        {
            IProductosServiceCentral svc = OperationContext.Current.GetCallbackChannel<IProductosServiceCentral>();
            Supplier supplier = svc.GetSupplierInfo();
            lock (this._monitor)
            {
                if (_suppliers.ContainsKey(supplier.Name))
                {
                    return false;
                }
                _suppliers.Add(supplier.Name, supplier);
            }
            System.Diagnostics.Debug.WriteLine("Supplier Registered {0} @ {1}", supplier.Name, supplier.EndPoint );
            return true;
        }

        public List<ProductFamily> GetSupplierProductFamilies(string supplierName)
        {
            var supplier = _suppliers[supplierName];
            if (supplier == null)
            {
                return null;
            }

            HashSet<ProductFamily> families = new HashSet<ProductFamily>();
            foreach (Product product in supplier.Products)
            {
                families.Add(product.Family);
            }
            return families.ToList();
        }

        public bool UnregisterSupplier(string supplierName)
        {
            bool result = false;
            lock (this._monitor)
            {
                if (!_suppliers.ContainsKey(supplierName))
                {
                    return false;
                }
                result = _suppliers.Remove(supplierName);
            }
            return result;
        }

        public void SignIn()
        {
            System.Diagnostics.Debug.WriteLine("Sign In: {0}", OperationContext.Current.Channel.RemoteAddress);
        }

        public void SignOut()
        {
            System.Diagnostics.Debug.WriteLine("Sign Out: {0}", OperationContext.Current.Channel.RemoteAddress);
        }

        public ContestInfoWithSuppliers CreateContest(string endPoint, Product product)
        {
            IComprasServiceCentral service = OperationContext.Current.GetCallbackChannel<IComprasServiceCentral>();
            Organization organization = service.GetOrganizationInfo();
            ContestInfo contest = new ContestInfo { Organization = organization, Product = product };
            int nextId = 0;
            List<Supplier> suppliersToNotify = null;
            lock (this._monitor)
            {
                suppliersToNotify =
                _suppliers.Values.Where(
                    supplier => supplier.Products.SingleOrDefault(prod => prod.Name.Equals(product.Name)) != null).ToList();

                if (suppliersToNotify.Count == 0)
                {
                    throw new FaultException<CentralServiceFault>(
                        new CentralServiceFault("No suppliers available for that product"));
                }

                var organizationInfo = OperationContext.Current.GetCallbackChannel<IComprasServiceCentral>().GetOrganizationInfo();
                contest.Organization = organizationInfo;
                if ( _contestInfos.Keys.Count != 0)
                {
                    nextId = _contestInfos.Keys.Max();    
                }
                ++nextId;
                contest.Id = nextId;
                _contestInfos.Add(nextId, contest);
            }
            foreach (var supplier in suppliersToNotify)
            {
                var client = new ProductosServiceCentralClient(
                    new BasicHttpBinding(BasicHttpSecurityMode.None), new EndpointAddress(supplier.EndPoint));
                client.NewContest(contest);
            }
            //Parallel.ForEach(suppliersToNotify, supplier =>
            //{
            //    var client = new ProductosServiceCentralClient(
            //        new BasicHttpBinding(BasicHttpSecurityMode.None), new EndpointAddress(supplier.EndPoint));
            //    client.NewContest(contest);
            //});

            ContestInfoWithSuppliers contestResult = new ContestInfoWithSuppliers
            {
                Id = nextId,
                Product = product,
                Suppliers = suppliersToNotify
            };

            return contestResult;
        }

        public List<Supplier> GetPossibleSuppliers(int proposalId)
        {
            ContestInfo contestInfo = _contestInfos[proposalId];
            if (contestInfo == null)
            {
                return null;
            }

            foreach (Supplier supplier in _suppliers.Values)
            {

            }
            return null;
        }
    }
}
