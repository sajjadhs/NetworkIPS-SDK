namespace NetworkIPSRestApi
{
    public class NetworkIPSConfig
    {
        public string GetBaseUrl()
        {
            if (IsSandBox)
                return "https://api-gateway.sandbox.ngenius-payments.com";
            else return "https://api-gateway.ngenius-payments.com";
        }
        public string OutletID { get; set; }
        public string ApiKey { get; set; }
        public bool IsSandBox { get; set; }
        public string ReturnUrl { get; set; }
        public string CancelUrl { get; set; }
    }
}
