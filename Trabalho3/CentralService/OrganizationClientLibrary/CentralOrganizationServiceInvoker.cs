namespace OrganizationClientLibrary.SupplierServiceClientLibrary
{
    using System.ServiceModel;

    using OrganizationClientLibrary.CentralService;

    public static class CentralOrganizationServiceInvoker
    {
        private static readonly ICentralOrganizationService client;
        public static OrganizationCallback CallbackContext { get; private set; }

        static CentralOrganizationServiceInvoker()
        {
            CallbackContext = new OrganizationCallback();
            InstanceContext context = new InstanceContext(CallbackContext);
            client = new CentralOrganizationServiceClient(context);
        }
    }
}