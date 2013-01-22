namespace Contracts.Types
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Organization
    {
        [DataMember]
        public string EndPoint { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}