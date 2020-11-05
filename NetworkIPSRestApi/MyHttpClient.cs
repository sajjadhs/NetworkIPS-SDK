using System;
using System.Net.Http;
using System.Text.Json;

namespace NetworkIPSRestApi
{

    public class MyHttpClient : HttpClient
    {
        private AccessToken accessToken;

        public MyHttpClient(NetworkIPSConfig environmet)
        {
            Environmet = environmet;
            BaseAddress = new Uri(environmet.GetBaseUrl());
        }

        public HttpResponseMessage Execute(HttpRequestMessage httpRequest)
        {
            if (accessToken == null || accessToken.IsAccessTokenExpired())
            {
                var res = this.SendAsync(new AuthorizationRequest(Environmet)).Result;
                string output = res.Content.ReadAsStringAsync().Result;
                accessToken = JsonSerializer.Deserialize<AccessToken>(output);
            }
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken.access_token);
            DefaultRequestHeaders.Add("accept", "application/vnd.ni-payment.v2+json");
            return SendAsync(httpRequest).Result;
        }

        private NetworkIPSConfig Environmet { get; }



    }
}
