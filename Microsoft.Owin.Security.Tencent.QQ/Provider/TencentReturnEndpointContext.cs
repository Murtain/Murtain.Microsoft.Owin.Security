using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Tencent.QQ.Provider
{
    public class TencentReturnEndpointContext : ReturnEndpointContext
    {
        public TencentReturnEndpointContext(IOwinContext context,AuthenticationTicket ticket) :
            base(context, ticket)
        {
        }

    }
}