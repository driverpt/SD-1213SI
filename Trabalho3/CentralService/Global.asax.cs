namespace CentralService
{
    using System;
    using System.Web;

    using Ninject;

    public class Global : Ninject.Web.Common.NinjectHttpApplication
    {
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel(new CentralServiceModule());
            return kernel;
        }
    }
}