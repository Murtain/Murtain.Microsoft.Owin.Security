using System;
using System.Net.Http;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Sina.Weibo.Provider;
using Owin;

namespace Microsoft.Owin.Security.Sina.Weibo
{
    public class WeiboAuthenticationMiddleware : AuthenticationMiddleware<WeiboAuthenticationOptions>
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;

        public WeiboAuthenticationMiddleware(OwinMiddleware next,IAppBuilder app,WeiboAuthenticationOptions options) 
            : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.ClientId))
                throw new ArgumentException("client_id can't be empty.");

            if (string.IsNullOrWhiteSpace(Options.ClientSecret))
                throw new ArgumentException("client_secret can't be empty.");

            if (string.IsNullOrWhiteSpace(Options.SignInAsAuthenticationType))
                Options.SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType();

            if (Options.StateDataFormat == null)
            {
                var dataProtector = app.CreateDataProtector(typeof(WeiboAuthenticationMiddleware).FullName,
                    Options.AuthenticationType,
                    "v1");

                Options.StateDataFormat = new PropertiesDataFormat(dataProtector);
            }

            if (Options.Provider == null)
                Options.Provider = new WeiboAuthenticationProvider();

            logger = app.CreateLogger<WeiboAuthenticationMiddleware>();
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 1024 * 1024 * 10
            };
        }

        protected override AuthenticationHandler<WeiboAuthenticationOptions> CreateHandler()
        {
            return new WeiboAuthenticationHandler(httpClient, logger);
        }
    }
}