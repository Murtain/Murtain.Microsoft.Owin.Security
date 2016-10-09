using System;
using System.Globalization;
using System.Security.Claims;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;

namespace Microsoft.Owin.Security.Tencent.QQ.Provider
{
    public class TencentAuthenticatedContext : BaseContext
    {
        public TencentAuthenticatedContext(IOwinContext context, JObject user, string accessToken, string refreshToken, string expires, string openId)
            : base(context)
        {
            AccessToken = accessToken;
            OpenId = openId;
            RefreshToken = refreshToken;

            int expiresValue;
            if (int.TryParse(expires, NumberStyles.Integer, CultureInfo.InvariantCulture, out expiresValue))
            {
                ExpiresIn = TimeSpan.FromSeconds(expiresValue);
            }
            NickName = TryGetValue(user, "nickname");
            Gender = TryGetValue(user, "gender");
            FigureUrl = TryGetValue(user, "figureurl_qq_1");
        }
        public string NickName { get; }
        public string Gender { get; }
        public string FigureUrl { get; }
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string OpenId { get; }
        public TimeSpan? ExpiresIn { get; }
        public ClaimsIdentity Identity { get; set; }
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }

    }
}