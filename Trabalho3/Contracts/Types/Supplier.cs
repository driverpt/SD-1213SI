namespace Contracts.Types
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// The supplier.
    /// </summary>
    [DataContract]
    public class Supplier
    {
        [DataMember]
        public string EndPoint { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }
    }
}