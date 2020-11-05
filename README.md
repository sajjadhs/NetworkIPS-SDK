# NetworkIPS .Net Based SDK

Handy [networkIPS](https://www.network.ae/en/contents/listing/payment-solutions) client which can be used in .net projects

This project is done over official  [networkips documentation](https://docs.ngenius-payments.com/reference#hosted-payment-page) and makes it easier and ready to use by one click.

Only thing you need is to get your outlet-id and api key from the NetworkIPS.

Call each function which is needed to get create payment, authorize payment, capture or refund it.

## Setup

Only clone the repository and add a reference to the project in yours.

## Code Usage

If you are using appseting.json file the define these keys:

```c#
 {
"AllowedHosts": "*",
  "NetworkIPSConfig": {

    "OutletID": "*********",
    "ApiKey": "********",
    "IsSandBox": true,
    "ReturnUrl": "https://127.0.0.1/payment/VerifyNips",
    "CancelUrl": "https://127.0.0.1/payment/Cancelled"
  }
```

Note: If you are going to publish your app to the Realworld/Production, then set IsSandBox to False

For Asp.net core register the NetworkIPSService at the startup:

```c#
services.Configure<NetworkIPSConfig>(options => Configuration.GetSection("NetworkIPSConfig").Bind(options));
services.AddSingleton<INetworkIPSService,NetworkIPSService>();
```

And your payment controller can be like below:
```c#
public class PaymentController : Controller
    {
        private readonly INetworkIPSService networkIPSService;
        public PaymentController(INetworkIPSService networkClient)
        {
            this.networkIPSService = networkClient;
        }
       public async Task<IActionResult> CreatePaymentNIPS(string amount, string pid)
        {
            
            var res = (await networkIPSService.CreateOrderAsync(amount, "smsoftbpt@gmail.com", new Dictionary<string, string>() { { "pid", pid } }));
            return Redirect(res.GetPaymentURL());

        }
        public async Task<IActionResult> VerifyNips([FromQuery(Name = "ref")] string referenceID, string pid)
        {
            
                var payment = await networkIPSService.CheckOrderStatus(referenceID);
                var p1 = payment.FirstOrDefault();
                var state = p1.state.ToLower();
                if (state == "authorised")
                {
                    //capture the payment
                    var result = await networkIPSService.CapturePaymentAsync(payment[0].orderReference, payment[0].GetPaymentID(), payment[0].amount.GetFormatedValue());
                    //capture-reference-id
                    string captureid = result.reference;
                }
                else if (state == "captured")
                {
                    //here means you deduct money from the user. so serve his service
                }
                else
                {
                    //it is cancelled
                }
          
            return Content("verified");
        }
    }
```

** Order type is set to sale by default,it means no need to capture the money because it will be captured automatically by networkips after successful payment,
If you want to control it manually then you will need to modify CreateOrderRequest file and set action="AUTH".

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change/add.


## License
[MIT](https://choosealicense.com/licenses/mit/)
