using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using NetworkIPSRestApi.Orders;

namespace NetworkIPSRestApi
{
    public class NetworkIPSService : INetworkIPSService
    {
        internal static MyHttpClient httpClient;
        private readonly NetworkIPSConfig environment;
        public NetworkIPSService(IOptions<NetworkIPSConfig> environmet)
        {
            this.environment = environmet.Value;
            httpClient = new MyHttpClient(environmet.Value);
        }
        public async Task<Order> CreateOrderAsync(string amount, string emailAddress, Dictionary<string, string> customParameters = null)
        {
            string url = environment.ReturnUrl;
            string cancelUrl = environment.CancelUrl;
            if (customParameters != null)
            {
                url = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(environment.ReturnUrl, customParameters);
                cancelUrl = Microsoft.AspNetCore.WebUtilities.QueryHelpers.AddQueryString(environment.CancelUrl, customParameters);
            }

            long normal_amount = long.Parse(amount.Replace(".", ""));
            return await CreateOrderHelper.CreateOrder(environment.OutletID, normal_amount, emailAddress, "AED", url, cancelUrl);
        }

        public async Task<List<Payment>> CheckOrderStatus(string orderRefrenceID)
        {
            var res = await OrderStatusHelper.GetOrderStatus(environment.OutletID, orderRefrenceID);
            return res;

        }


        public async Task<Order> CapturePaymentAsync(string orderReferenceId, string paymentReferenceID, string amount)
        {
            long normal_amount = long.Parse(amount.Replace(".", ""));
            var res = await CaptureHelper.Capture(environment.OutletID, orderReferenceId, paymentReferenceID, normal_amount, "AED");
            return res;
        }

        public async Task<Order> RefundPaymentAsync(string orderReferenceId, string paymentReferenceID, string captureReferenceId, string amount)
        {
            long normal_amount = long.Parse(amount.Replace(".", ""));
            var res = await RefundHelper.Refund(environment.OutletID, orderReferenceId, paymentReferenceID, captureReferenceId, normal_amount, "AED");
            return res;
        }


    }
}
