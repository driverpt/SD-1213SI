using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplierClientConsole
{
    using SupplierServiceClientLibrary;

    class Program
    {
        static void Main(string[] args)
        {
            SupplierServiceInvoker.RegisterSupplier(SupplierServiceInvoker.CallbackContext.GetSupplierInfo());
            Console.ReadKey();
        }
    }
}
