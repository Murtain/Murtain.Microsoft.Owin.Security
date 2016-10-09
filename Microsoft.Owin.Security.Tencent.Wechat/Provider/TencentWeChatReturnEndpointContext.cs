using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Tencent.Wechat.Provider
{
    public class TencentWeChatReturnEndpointContext : ReturnEndpointContext
    {
        public TencentWeChatReturnEndpointContext(
            IOwinContext context,
            AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }

    }
}
