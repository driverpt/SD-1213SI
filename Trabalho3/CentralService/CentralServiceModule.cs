namespace CentralService
{
    using Contracts;

    using DataAccessLayer;

    using DomainLayer.Interfaces;
    using DomainLayer.Service;
    using DomainLayer.Types;

    using Ninject.Modules;

    public class CentralServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ICentralOrganizationService>().To<CentralOrganizationService>();
            this.Bind<ICentralSupplierService>().To<CentralSupplierService>();
            this.Bind<IRepository<Supplier, string>>().To<SuppliersMemoryRepository>().InSingletonScope();
            this.Bind<IRepository<ContestInfo, int>>().To<ContestInfoMemoryRepository>().InSingletonScope();
            this.Bind<IRepository<Organization, int>>().To<OrganizationMemoryRepository>().InSingletonScope();
            this.Bind<ContestService>();
            this.Bind<OrganizationService>();
            this.Bind<SuppliersService>();
        }
    }
}