using System.Collections.Generic;

namespace NetworkIPSRestApi
{
    public class PaymentMethod
    {
        public List<string> card { get; set; }
        public List<string> wallet { get; set; }
    }
}
