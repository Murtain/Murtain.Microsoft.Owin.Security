using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Tencent.Wechat.Provider
{
    public interface ITencentWeChatAuthenticationProvider
    {
        Task Authenticated(TencentWeChatAuthenticatedContext context);
        Task ReturnEndpoint(TencentWeChatReturnEndpointContext context);
        void ApplyRedirect(TencentWeChatApplyRedirectContext context);
    }
}
