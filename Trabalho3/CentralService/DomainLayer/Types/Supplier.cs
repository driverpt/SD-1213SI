namespace DomainLayer.Types
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using DomainLayer.Interfaces;

    [DataContract]
    public class Supplier : IDomainModel<string>
    {
        [DataMember]
        public string EndPoint { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Product> Products { get; set; }

        [IgnoreDataMember]
        public string Id
        {
            get
            {
                return this.Name;
            }
            set
            {
                this.Name = value;
            }
        }
    }

    [DataContract]
    public class Organization : IDomainModel<int>
    {
        [IgnoreDataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string EndPoint { get; set; }
    }
}