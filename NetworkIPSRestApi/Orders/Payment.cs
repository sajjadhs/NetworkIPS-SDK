using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkIPSRestApi.Orders
{
    public class Payment
    {
        /// <summary>
        /// this is payment id
        /// </summary>
        public string _id { get; set; }


        public string GetPaymentID()
        {
            return _id.Replace("urn:payment:", "");
        }

        //AUTH or SALE
        public Amount amount { get; set; }
     
      
        public Link2 _links { get; set; }

        public string state { get; set; }
        public string reference { get; set; }
        public string outletId { get; set; }
        public DateTime updateDateTime { get; set; }
        public string orderReference { get; set; }
      
       
    }
}
