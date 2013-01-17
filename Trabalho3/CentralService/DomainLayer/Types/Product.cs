namespace DomainLayer.Types
{
    using System;
    using System.Runtime.Serialization;

    using DomainLayer.Interfaces;

    [DataContract]
    public class ProductFamily
    {
        [DataMember]
        public string Name { get; set; }
    }

    [Serializable]
    [DataContract]
    public class Product : IDomainModel<int>
    {
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember]
        public ProductFamily Family { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}