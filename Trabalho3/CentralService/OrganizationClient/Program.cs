using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizationClient
{
    using System.ServiceModel;

    using OrganizationClient.CentralService;
    using OrganizationClient.ProductosService;

    using Organization = OrganizationClient.CentralService.Organization;
    using Product = OrganizationClient.CentralService.Product;

    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new OrganizationCallback());
            ICentralOrganizationService client = new CentralOrganizationServiceClient(context);
            Product product = new Product { Name = "Primavera" };
            client.SignIn();
            client.CreateContest(null, product);
            client.SignOut();
            Console.ReadKey();
        }

        static void Main2(string[] args)
        {
            IProductosService client = new ProductosServiceClient(new BasicHttpBinding(BasicHttpSecurityMode.None), new EndpointAddress("<Insert Endpoint here>"));
            client.AcceptProposal(1);
            //client.RejectProposal(1);
            Console.ReadKey();
        }
    }

    public class OrganizationCallback : ICentralOrganizationServiceCallback
    {
        public Organization GetOrganizationInfo()
        {
            return new Organization
                       {
                           Name = "Organization 1",
                           EndPoint = "http://localhost:24565/OrganizationService.svc"
                       };
        }
    }
}
