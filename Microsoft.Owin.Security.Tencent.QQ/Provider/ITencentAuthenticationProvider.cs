using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Owin.Security.Tencent.QQ.Provider
{
    public interface ITencentAuthenticationProvider
    {
        Task Authenticated(TencentAuthenticatedContext context);

        Task ReturnEndpoint(TencentReturnEndpointContext context);

        void ApplyRedirect(TencentApplyRedirectContext context);
    }
}
