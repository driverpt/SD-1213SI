namespace DataAccessLayer
{
    using System.Collections.Generic;

    using DomainLayer.Types;

    public class SuppliersMemoryRepository : BaseMemoryRepository<Supplier, string>
    {
        private static IDictionary<string, Supplier> Repo = new Dictionary<string, Supplier>();
        public SuppliersMemoryRepository() : base(Repo) { }
    }
}