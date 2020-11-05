using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetworkIPSRestApi.Orders;

namespace NetworkIPSRestApi
{
    public class CaptureHelper
    {
        public static async Task<Order> Capture(string outletID,string orderReference,string paymentReference,long amount,string currencyCode)
        {
            var res = NetworkIPSService.httpClient.Execute(new CreateCaptureRequest(outletID,orderReference,paymentReference,amount,currencyCode));
            string output = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Order>(output);
            
        }
    }
}
