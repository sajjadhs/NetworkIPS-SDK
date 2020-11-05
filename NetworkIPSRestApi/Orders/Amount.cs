namespace NetworkIPSRestApi
{
    public class Amount
    {
        public long value { get; set; }
        /// <summary>
        /// AED,USD, EUR
        /// </summary>
        public string currencyCode { get; set; }

        public string GetFormatedValue()
        {
            decimal temp = value / 100.00M;
            return temp.ToString("#.##");
        }

    }
}
