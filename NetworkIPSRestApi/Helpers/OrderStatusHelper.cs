using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NetworkIPSRestApi.Orders;

namespace NetworkIPSRestApi
{
    public class OrderStatusHelper
    {
        public static async Task<List<Payment>> GetOrderStatus(string outletID,string orderReference)
        {
            var res = NetworkIPSService.httpClient.Execute(new CreateOrderStatusRequest(outletID,orderReference));
            string output = await res.Content.ReadAsStringAsync();
            var status = JsonSerializer.Deserialize<Order>(output);
            return status._embedded.payment;
        }
    }
}
