using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace Microsoft.Owin.Security.Sina.Weibo
{
    public static class WeiboAuthenticationExtensions
    {
        public static IAppBuilder UseWeiboAuthentication(this IAppBuilder app, WeiboAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(WeiboAuthenticationMiddleware), app, options);
            return app;
        }

        public static IAppBuilder UseWeiboAuthentication(this IAppBuilder app, string clientId, string clientSecret)
        {
            app.Use(typeof(WeiboAuthenticationMiddleware), app, new WeiboAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
            return app;
        }


    }
}
