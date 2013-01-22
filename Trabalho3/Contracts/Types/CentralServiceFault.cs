namespace Contracts.Types
{
    using System.Runtime.Serialization;

    [DataContract]
    public class CentralServiceFault
    {
        public string ErrorMessage { get; set; }

        public CentralServiceFault(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }
    }
}