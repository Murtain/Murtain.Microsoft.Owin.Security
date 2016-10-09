using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;

namespace Microsoft.Owin.Security.Tencent.Wechat.Provider
{
    public class TencentWeChatAuthenticatedContext : BaseContext
    {
        public TencentWeChatAuthenticatedContext(IOwinContext context,JObject user,string accessToken,string refreshToken,string expireIn,string openId)
            : base(context)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            OpenId = openId;
            User = user;
            int expiresValue;
            if (int.TryParse(expireIn, NumberStyles.Integer, CultureInfo.InvariantCulture, out expiresValue))
            {
                ExpiresIn = TimeSpan.FromSeconds(expiresValue);
            }
            NickName = TryGetValue(user,"nickname");
            Sex = TryGetValue(user, "sex"); 
            Province = TryGetValue(user, "province");
            Country = TryGetValue(user, "country");
            City = TryGetValue(user, "city");
            Unionid = TryGetValue(user, "unionid"); 
            HeadimgUrl = TryGetValue(user, "headimgurl");
        }

        public JObject User { get; }
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string OpenId { get; }
        public TimeSpan? ExpiresIn { get; }
        public string NickName { get; }
        public string Sex { get; }
        public string Province { get; }
        public string Country { get; }
        public string City { get; }
        public string Unionid { get; }
        public string HeadimgUrl { get; }

        public ClaimsIdentity Identity { get; set; }
        public AuthenticationProperties Properties { get; set; }


        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}
