using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace Microsoft.Owin.Security.Tencent.Wechat
{
    public static class TencentWeChatAuthenticationExtensions
    {
        public static IAppBuilder UseWeChatAuthentication(this IAppBuilder app, TencentWeChatAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(TencentWeChatAuthenticationMiddleware), app, options);
            return app;
        }

        public static IAppBuilder UseWeChatAuthentication(this IAppBuilder app, string appId, string appSecret)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            app.Use(typeof(TencentWeChatAuthenticationMiddleware), app, new TencentWeChatAuthenticationOptions
            {
                AppId = appId,
                AppSecret = appSecret
            });
            return app;
        }
    }
}
