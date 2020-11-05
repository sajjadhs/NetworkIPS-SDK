using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NetworkIPSRestApi.Orders
{
    [DataContract]
    public class Link2
    {
        [DataMember(Name = "cnp:cancel")]
        public Link cancel{get;set;}
        [DataMember(Name = "cnp:capture")]
        public Link capture { get; set; }
        public List<object> curies { get; set; }
    }
}
