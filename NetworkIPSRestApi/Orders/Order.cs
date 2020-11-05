using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkIPSRestApi
{
    public class Order
    {
      
        //AUTH or SALE
        public string action { get; set; }
        public Amount amount { get; set; }
        /// <summary>
        /// en - ar - fr
        /// </summary>
        public string language { get; set; } = "en";
        public string emailAddress { get; set; }
        public Merchant merchantAttributes { get; set; }

        public Dictionary<string, Link> _links { get; set; }

        public string GetPaymentURL()
        {
            if (_links.ContainsKey("payment"))
            {
                return _links.FirstOrDefault(w => w.Key == "payment").Value.href;
            }
            return "";
        }
     
        public string reference { get; set; }
        public string outletId { get; set; }
        public DateTime createDateTime { get; set; }

        public PaymentMethod paymentMethods { get; set; }
        public string formattedAmount { get; set; }

        public Embeded _embedded { get; set; }
    }
}
