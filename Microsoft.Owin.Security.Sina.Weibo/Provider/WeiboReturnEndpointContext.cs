﻿using Microsoft.Owin.Security.Provider;

namespace Microsoft.Owin.Security.Sina.Weibo.Provider
{
    public class WeiboReturnEndpointContext : ReturnEndpointContext
    {
        public WeiboReturnEndpointContext(IOwinContext context,AuthenticationTicket ticket) 
            : base(context, ticket)
        {
        }

    }
}