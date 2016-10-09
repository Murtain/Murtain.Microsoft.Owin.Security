using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Tencent.QQ.Provider
{
    public class TencentAuthenticationProvider : ITencentAuthenticationProvider
    {
        public TencentAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null); ;
            OnReturnEndpoint = context => Task.FromResult<object>(null); ;
            OnApplyRedirect = context => context.Response.Redirect(context.RedirectUri);
        }

        public Func<TencentAuthenticatedContext, Task> OnAuthenticated { get; set; }
        public Func<TencentReturnEndpointContext, Task> OnReturnEndpoint { get; set; }
        public Action<TencentApplyRedirectContext> OnApplyRedirect { get; set; }
        public virtual Task Authenticated(TencentAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        public virtual Task ReturnEndpoint(TencentReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }

        public virtual void ApplyRedirect(TencentApplyRedirectContext context)
        {
            OnApplyRedirect(context);
        }
    }
}
