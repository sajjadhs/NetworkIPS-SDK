using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace NetworkIPSRestApi
{

    public class CreateCaptureRequest : HttpRequestMessage
    {
        public CreateCaptureRequest(string outletID, string orderReference,string paymentReference,long amount,string currencyCode) : base(HttpMethod.Post, "/transactions/outlets/{outlet}/orders/{order}/payments/{payment}/captures"
            .Replace("{outlet}", outletID)
            .Replace("{order}", orderReference)
            .Replace("{payment}",paymentReference))
        { 
            var res = JsonSerializer.Serialize(new Order
            {
                amount = new Amount { value = amount, currencyCode = currencyCode },
            });
            this.Content = new System.Net.Http.StringContent(res, Encoding.UTF8, "application/json");
            this.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ni-payment.v2+json");
        }


    }
}
