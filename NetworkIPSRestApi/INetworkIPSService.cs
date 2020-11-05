using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetworkIPSRestApi.Orders;

namespace NetworkIPSRestApi
{
    public interface INetworkIPSService
    {
        /// <summary>
        /// step1 - will create payment request. the you should redirect to URL
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        Task<Order> CreateOrderAsync(string amount, string emailAddress, Dictionary<string, string> customParameters = null);
        /// <summary>
        /// step2 - should check the payment status
        /// if it is <b>AUTHORISED</b> then need to caputre
        /// if it is <b>CAPTURED</b> no more thing to do
        /// if it is <b>FAILED</b> then need to retry with user
        /// </summary>
        /// <param name="orderRefrenceID"></param>
        /// <returns></returns>
        Task<List<Payment>> CheckOrderStatus(string orderRefrenceID);
        Task<Order> CapturePaymentAsync(string orderReferenceId, string paymentReferenceID, string amount);
        Task<Order> RefundPaymentAsync(string orderReferenceId, string paymentReferenceID, string captureReferenceId, string amount);


    }
}
