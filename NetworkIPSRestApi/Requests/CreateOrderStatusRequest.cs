using System.Net.Http;
using System.Text.Json;

namespace NetworkIPSRestApi
{
    internal class CreateOrderStatusRequest : HttpRequestMessage
    {

        public CreateOrderStatusRequest(string outletID, string orderReference) : base(HttpMethod.Get, "/transactions/outlets/{outlet}/orders/{order}".Replace("{outlet}", outletID).Replace("{order}",orderReference))
        {
          
        }
    }
}
