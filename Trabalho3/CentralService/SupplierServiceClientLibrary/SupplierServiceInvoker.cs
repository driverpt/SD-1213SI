using System;
using System.Collections.Generic;

namespace SupplierServiceClientLibrary
{
    using System.ServiceModel;

    using Contracts;
    using Contracts.Types;

    using SupplierServiceClientLibrary.CentralService;

    using ICentralSupplierService = SupplierServiceClientLibrary.CentralService.ICentralSupplierService;
    using Product = Contracts.Types.Product;
    using ProductFamily = Contracts.Types.ProductFamily;

    public static class SupplierServiceInvoker
    {
        private static readonly ICentralSupplierService client;
        public static SupplierCallback CallbackContext { get; private set; }

        static SupplierServiceInvoker()
        {
            CallbackContext = new SupplierCallback();
            InstanceContext context = new InstanceContext(CallbackContext);
            
            client = new CentralSupplierServiceClient(context);
        }

        public static bool RegisterSupplier(Supplier supplier)
        {
            return client.RegisterSupplier(supplier);
        }

        public static bool UnregisterSupplier(string name)
        {
            return client.UnregisterSupplier(name);
        }
    }

    public class SupplierCallback : ICentralSupplierServiceCallback
    {
        public Contracts.Types.Supplier GetSupplierInfo()
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
                EndPoint = "http://localhost:25262/ProductosService.svc/Central",
                Name = "Supplier 1",
                Products = products
            };
        }

        public void NewContest(ContestInfo contest)
        {
            throw new NotImplementedException();
        }
    }
}
