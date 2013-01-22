namespace Contracts.Types
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The product family.
    /// </summary>
    [DataContract]
    public class ProductFamily
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}