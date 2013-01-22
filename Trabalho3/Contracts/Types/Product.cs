namespace Contracts.Types
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The product.
    /// </summary>
    [DataContract]
    public class Product
    {
        [IgnoreDataMember]
        public int Id { get; set; }
        [DataMember]
        public ProductFamily Family { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}