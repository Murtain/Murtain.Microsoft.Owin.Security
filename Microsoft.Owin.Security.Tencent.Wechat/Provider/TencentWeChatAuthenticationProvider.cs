using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Tencent.Wechat.Provider
{
    public class TencentWeChatAuthenticationProvider : ITencentWeChatAuthenticationProvider
    {
        public TencentWeChatAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
            OnApplyRedirect = context => context.Response.Redirect(context.RedirectUri);
        }

        public Func<TencentWeChatAuthenticatedContext, Task> OnAuthenticated { get; set; }
        public Func<TencentWeChatReturnEndpointContext, Task> OnReturnEndpoint { get; set; }
        public Action<TencentWeChatApplyRedirectContext> OnApplyRedirect { get; set; }

        public virtual Task Authenticated(TencentWeChatAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        public virtual Task ReturnEndpoint(TencentWeChatReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }

        public virtual void ApplyRedirect(TencentWeChatApplyRedirectContext context)
        {
            OnApplyRedirect(context);
        }
    }
}
