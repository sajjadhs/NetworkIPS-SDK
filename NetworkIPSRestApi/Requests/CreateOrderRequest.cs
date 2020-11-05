using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace NetworkIPSRestApi
{

    public class CreateOrderRequest : HttpRequestMessage
    {
        public CreateOrderRequest(string outletID, long amount, string userEmail, string currencyCode, string redirectUrl, string cancelUrl) : base(HttpMethod.Post, "/transactions/outlets/{outlet}/orders".Replace("{outlet}", outletID))
        {
            var res = JsonSerializer.Serialize(new Order
            {
                action = "SALE",
                amount = new Amount { value = amount, currencyCode = currencyCode },
                merchantAttributes = new Merchant { cancelUrl = cancelUrl, redirectUrl = redirectUrl, },
                language = "en",
                emailAddress = userEmail,


            });
            this.Content = new System.Net.Http.StringContent(res, Encoding.UTF8, "application/json");
            this.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ni-payment.v2+json");
        }


    }
}
