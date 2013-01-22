namespace Contracts.Types
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The contest info.
    /// </summary>
    [DataContract]
    public class ContestInfo
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public Organization Organization { get; set; }
    }

    [DataContract]
    public class ContestInfoWithSuppliers
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public IEnumerable<Supplier> Suppliers { get; set; }
    }
}