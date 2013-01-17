using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CentralService
{
    using Contracts;

    using DomainLayer.Types;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CentralSupplierService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CentralSupplierService.svc or CentralSupplierService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CentralSupplierService : ICentralSupplierService
    {
        private readonly object _monitor = new object();
        private static IDictionary<string, Supplier> Suppliers;

        private static IDictionary<int, ContestInfo> contestInfos;

        private readonly CentralSupplierService supplierService;

        public CentralSupplierService()
        {
            Suppliers = new Dictionary<string, Supplier>();
            contestInfos = new Dictionary<int, ContestInfo>();
        }

        public CentralSupplierService(CentralSupplierService service) : this()
        {
            supplierService = service;
            
        }

        public bool RegisterSupplier(Supplier supplier)
        {
            lock (this._monitor)
            {
                if (Suppliers.ContainsKey(supplier.Name))
                {
                    return false;
                }
                Suppliers.Add(supplier.Name, supplier);
            }
            return true;
        }

        public List<ProductFamily> GetSupplierProductFamilies(string supplierName)
        {
            var supplier = Suppliers[supplierName];
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
                if (!Suppliers.ContainsKey(supplierName))
                {
                    return false;
                }
                result = Suppliers.Remove(supplierName);
            }
            return result;
        }

        public void RegisterOrganization(string name, string endPoint)
        {

        }

        public void SignIn()
        {

        }

        public void SignOut()
        {

        }

        public int CreateProposal(string endPoint, Product product)
        {
            lock (this._monitor)
            {
                int nextId = contestInfos.Keys.Max();
                ++nextId;
                ContestInfo contestInfo = new ContestInfo { EndPoint = endPoint, Product = product };
                contestInfos.Add(nextId, contestInfo);
                return nextId;
            }
        }

        public List<Supplier> GetPossibleSuppliers(int proposalId)
        {
            ContestInfo contestInfo = contestInfos[proposalId];
            if (contestInfo == null)
            {
                return null;
            }

            foreach (Supplier supplier in Suppliers.Values)
            {

            }
            return null;
        }
    }
}
