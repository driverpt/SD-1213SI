namespace DomainLayer.Types
{
    using System.Runtime.Serialization;

    using DomainLayer.Interfaces;

    [DataContract]
    public class ContestInfo : IDomainModel<int>
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string EndPoint { get; set; }
        [DataMember]
        public Product Product { get; set; }
        [DataMember]
        public Organization Organization { get; set; }
    }
}