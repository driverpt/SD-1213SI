using System.Collections.Generic;
using System.ServiceModel;

namespace ProductosService
{
    using Contracts;
    using Contracts.Types;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductosService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductosService.svc or ProductosService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProductosService : IProductosService, IProductosServiceCentral
    {
        private static IDictionary<int, ContestInfoWithBool> Contests = new Dictionary<int, ContestInfoWithBool>();

        public void NewContest(ContestInfo info)
        {
            System.Diagnostics.Debug.WriteLine("New Contest Arrived");
            System.Diagnostics.Debug.WriteLine("ID: {0}, Organization: {1}, Product: {2}", info.Id, info.Organization.Name, info.Product.Name);
            ContestInfoWithBool moreComplexInfo = new ContestInfoWithBool(info);
            Contests.Add(info.Id, moreComplexInfo);
        }

        public void AcceptProposal(int contestId)
        {
            // TODO: Fazer verificação se quem faz o pedido é a mesma organização que está guardada no objecto Organization.
            // TODO: Throw SOAPFault if no contest exists locally
            Contests[contestId].IsAccepted = true;
            Contests[contestId].IsFinished = true;
        }

        public void RejectProposal(int contestId)
        {
            Contests[contestId].IsAccepted = false;
            Contests[contestId].IsFinished = true;
        }

        public Supplier GetSupplierInfo()
        {
            List<Product> products = new List<Product>();
            ProductFamily hardware = new ProductFamily { Name = "Hardware" };
            ProductFamily software = new ProductFamily { Name = "Software" };

            Product primavera = new Product { Family = software, Name = "Primavera" };
            Product artsoft = new Product { Family = software, Name = "Artsoft" };

            Product radeon = new Product { Family = hardware, Name = "ATI Radeon HD" };
            Product nvidia = new Product { Family = hardware, Name = "nVidia GeForce" };

            Product raspberryPi = new Product { Family = hardware, Name = "Raspberry Pi" };

            products.Add(primavera);
            products.Add(artsoft);
            products.Add(radeon);
            products.Add(nvidia);
            products.Add(raspberryPi);

            return new Supplier
                       {
                           EndPoint = OperationContext.Current.Channel.LocalAddress.ToString(),
                           Name = "Supplier 1",
                           Products = products
                       };
        }
    }

    public class ContestInfoWithBool : ContestInfo
    {
        public ContestInfoWithBool(ContestInfo contestInfo)
        {
            Id = contestInfo.Id;
            Organization = contestInfo.Organization;
            Product = contestInfo.Product;
            IsAccepted = false;
            IsFinished = false;
        }

        public bool IsAccepted { get; set; }
        public bool IsFinished { get; set; }
    }
}
