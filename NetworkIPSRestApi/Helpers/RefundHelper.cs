using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetworkIPSRestApi.Orders;

namespace NetworkIPSRestApi
{
    public class RefundHelper
    {
        public static async Task<Order> Refund(string outletID, string orderReference, string paymentReference, string captureReference, long amount, string currencyCode)
        {
            var res = NetworkIPSService.httpClient.Execute(new CreateRefundRequest(outletID, orderReference, paymentReference, captureReference, amount, currencyCode));
            string output = await res.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Order>(output);

        }
    }
}
