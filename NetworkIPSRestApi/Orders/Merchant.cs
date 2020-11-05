namespace NetworkIPSRestApi
{
    public class Merchant
    {
        public string redirectUrl { get; set; }
        public string skipConfirmationPage { get; set; } = "true";
        public string cancelUrl { get; set; }
        public string cancelText { get; set; } = "Return To Website";
    }
}
