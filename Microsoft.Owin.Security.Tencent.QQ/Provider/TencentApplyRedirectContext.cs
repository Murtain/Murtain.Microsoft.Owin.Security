using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Tencent.QQ.Provider
{
    public class TencentApplyRedirectContext : BaseContext<TencentAuthenticationOptions>
    {
        public TencentApplyRedirectContext(IOwinContext context,TencentAuthenticationOptions options, string redirectUri, AuthenticationProperties properties)
            : base(context, options)
        {
            RedirectUri = redirectUri;
            Properties = properties;
        }

        public string RedirectUri { get; }
        public AuthenticationProperties Properties { get; }
    }
}