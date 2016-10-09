using System;
using System.Net.Http;
using Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Tencent.QQ.Provider;

namespace Microsoft.Owin.Security.Tencent.QQ
{
    public class TencentAuthenticationMiddleware : AuthenticationMiddleware<TencentAuthenticationOptions>
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        public TencentAuthenticationMiddleware(OwinMiddleware next,IAppBuilder app,TencentAuthenticationOptions options) : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
                throw new ArgumentException("appId can't be empty.");

            if (string.IsNullOrWhiteSpace(Options.AppKey))
                throw new ArgumentException("app_secret can't be empty.");

            if (Options.Provider == null)
                Options.Provider = new TencentAuthenticationProvider();

            if (Options.StateDataFormat == null)
            {
                var dataProtector = app.CreateDataProtector(typeof(TencentAuthenticationMiddleware).FullName,
                    Options.AuthenticationType, "v1");
                Options.StateDataFormat = new PropertiesDataFormat(dataProtector);
            }

            if (String.IsNullOrEmpty(Options.SignInAsAuthenticationType))
                Options.SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType();

            logger = app.CreateLogger<TencentAuthenticationMiddleware>();
            httpClient = new HttpClient(new WebRequestHandler())
            {
                MaxResponseContentBufferSize = 1024 * 1024 * 10
            };
        }

        protected override AuthenticationHandler<TencentAuthenticationOptions> CreateHandler()
        {
            return new TencentAuthenticationHandler(httpClient, logger);
        }
    }
}