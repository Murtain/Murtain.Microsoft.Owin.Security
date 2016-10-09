using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Tencent.Wechat.Provider
{
    public class TencentWeChatApplyRedirectContext : BaseContext<TencentWeChatAuthenticationOptions>
    {
        public TencentWeChatApplyRedirectContext(IOwinContext context,TencentWeChatAuthenticationOptions options,string redirectUri,AuthenticationProperties properties)
            : base(context, options)
        {
            RedirectUri = redirectUri;
            Properties = properties;
        }

        public string RedirectUri { get; }
        public AuthenticationProperties Properties { get; }
    }
}
