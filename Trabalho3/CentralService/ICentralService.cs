namespace CentralService
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ICentralService
    {
        [OperationContract(IsOneWay = false)]
        bool RegisterSupplier(string supplierName, List<ProductFamily> products);

        [OperationContract(IsOneWay = false)]
        bool UnRegisterSupplier(string supplierName);

        [OperationContract(IsOneWay = false)]
        List<ProductFamily> GetSupplierProductFamilies(string supplierName);
    }
}