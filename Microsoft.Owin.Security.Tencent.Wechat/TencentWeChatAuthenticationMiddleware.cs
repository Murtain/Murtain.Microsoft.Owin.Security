using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.Tencent.Wechat.Provider;
using Owin;

namespace Microsoft.Owin.Security.Tencent.Wechat
{
    public class TencentWeChatAuthenticationMiddleware : AuthenticationMiddleware<TencentWeChatAuthenticationOptions>
    {
        private readonly HttpClient httpClient;
        private readonly ILogger logger;
        public TencentWeChatAuthenticationMiddleware(OwinMiddleware next,IAppBuilder app,TencentWeChatAuthenticationOptions options) 
            : base(next, options)
        {
            if (string.IsNullOrWhiteSpace(Options.AppId))
                throw new ArgumentException("appId can't be empty.");

            if (String.IsNullOrWhiteSpace(Options.AppSecret))
                throw new ArgumentException("app_secret can't be empty.");

            if (Options.Provider == null)
                Options.Provider = new TencentWeChatAuthenticationProvider();

            if (Options.StateDataFormat == null)
            {
                var dataProtector = app.CreateDataProtector(typeof(TencentWeChatAuthenticationHandler).FullName, Options.AuthenticationType, "v1");
                Options.StateDataFormat = new PropertiesDataFormat(dataProtector);
            }
            if (string.IsNullOrEmpty(Options.SignInAsAuthenticationType))
                Options.SignInAsAuthenticationType = app.GetDefaultSignInAsAuthenticationType();

            this.logger = app.CreateLogger<TencentWeChatAuthenticationMiddleware>();

            this.httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 1024 * 1024 * 10
            };
        }

        protected override AuthenticationHandler<TencentWeChatAuthenticationOptions> CreateHandler()
        {
            return new TencentWeChatAuthenticationHandler(this.logger, this.httpClient);
        }
    }
}
