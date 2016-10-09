using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace Microsoft.Owin.Security.Tencent.QQ
{
    public static class TencentAuthenticationExtensions
    {
        public static IAppBuilder UseTencentAuthentication(this IAppBuilder app, TencentAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(TencentAuthenticationMiddleware), app, options);
            return app;
        }

        public static IAppBuilder UseTencentAuthentication(this IAppBuilder app, string appId, string appKey)
        {
            app.Use(typeof(TencentAuthenticationMiddleware), app, new TencentAuthenticationOptions
            {
                AppId = appId,
                AppKey = appKey
            });
            return app;
        }
    }
}
