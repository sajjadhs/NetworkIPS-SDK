using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace NetworkIPSRestApi
{

    public class CreateRefundRequest : CreateCaptureRequest
    {
        public CreateRefundRequest(string outletID, string orderReference, string paymentReference, string captureReference, long amount, string currencyCode) : base(outletID,orderReference,paymentReference,amount,currencyCode)
        {
            RequestUri= new System.Uri(base.RequestUri.AbsoluteUri + "/{capture}/refund".Replace("{capture}",captureReference));
        }


    }
}
