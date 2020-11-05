using System;
using System.Runtime.Serialization;

namespace NetworkIPSRestApi
{
   
    public class AccessToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int refresh_expires_in { get; set; }

        private DateTime createDate { get; set; }
        public AccessToken()
        {
            this.createDate = DateTime.Now;
        }

        public bool IsAccessTokenExpired()
        {
            DateTime expireDate = this.createDate.Add(TimeSpan.FromSeconds(this.expires_in));
            return DateTime.Now.CompareTo(expireDate) > 0;
        }
    }
}
