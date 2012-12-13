using System.Collections.Generic;

namespace CentralService
{
    using System.ServiceModel;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CentralService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CentralService.svc or CentralService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single)]
    public class CentralService : ICentralService
    {
        private readonly object _monitor = new object();
        private static IDictionary<string, List<ProductFamily>> ProductFamilies;

        private CentralService()
        {
            ProductFamilies = new Dictionary<string, List<ProductFamily>>();
        }

        public bool RegisterSupplier(string supplierName, List<ProductFamily> products)
        {
            lock (_monitor)
            {
                if (ProductFamilies.ContainsKey(supplierName))
                {
                    return false;
                }
                ProductFamilies.Add(supplierName, products);
            }
            return true;
        }

        public List<ProductFamily> GetSupplierProductFamilies(string supplierName)
        {
            return ProductFamilies[supplierName];
        }

        public bool UnRegisterSupplier(string supplierName)
        {
            bool result = false;
            lock (_monitor)
            {
                if (!ProductFamilies.ContainsKey(supplierName))
                {
                    return false;
                }
                result = ProductFamilies.Remove(supplierName);
            }
            return result;
        }
    }
}
