using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Sina.Weibo.Provider
{
    public class WeiboApplyRedirectContext : BaseContext<WeiboAuthenticationOptions>
    {
        public WeiboApplyRedirectContext(IOwinContext context,WeiboAuthenticationOptions options,string redirectUri,AuthenticationProperties properties) 
            : base(context, options)
        {
            RedirectUri = redirectUri;
            Properties = properties;
        }

        public string RedirectUri { get; }
        public AuthenticationProperties Properties { get; }
    }
}