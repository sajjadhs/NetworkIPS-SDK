using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetworkIPSRestApi
{
    public class CreateOrderHelper
    {
        public static async Task<Order> CreateOrder(string outletID, long amount, string userEmail, string currencyUnit, string redirectUrl, string cancelUrl)
        {
            var res = NetworkIPSService.httpClient.Execute(new CreateOrderRequest(outletID, amount, userEmail, currencyUnit, redirectUrl, cancelUrl));
            string output = await res.Content.ReadAsStringAsync();
            if (!res.IsSuccessStatusCode)
            {
                throw new WebException("errors in creating order");
            }
            return JsonSerializer.Deserialize<Order>(output);
        }

    }
}
