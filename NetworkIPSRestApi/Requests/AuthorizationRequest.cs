using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetworkIPSRestApi
{

    public class AuthorizationRequest : HttpRequestMessage
    {

        public AuthorizationRequest(NetworkIPSConfig environment) : base(HttpMethod.Post,"/identity/auth/access-token")
        {
            Headers.Clear();
            Headers.Add("accept", "application/vnd.ni-identity.v1+json");
            Headers.Authorization = new AuthenticationHeaderValue("Basic", environment.ApiKey);
            var f=new System.Net.Http.StringContent("{\"realmName\":\"ni\"}", Encoding.UTF8, "application/json");
            this.Content = f;
            this.Content.Headers.ContentType= new MediaTypeHeaderValue("application/vnd.ni-identity.v1+json");
        }


    }
}
