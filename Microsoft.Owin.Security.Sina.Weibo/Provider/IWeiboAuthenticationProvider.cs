using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Sina.Weibo.Provider
{
    public interface IWeiboAuthenticationProvider
    {
        Task Authenticated(WeiboAuthenticatedContext context);
        Task ReturnEndpoint(WeiboReturnEndpointContext context);
        void ApplyRedirect(WeiboApplyRedirectContext context);

    }
}
