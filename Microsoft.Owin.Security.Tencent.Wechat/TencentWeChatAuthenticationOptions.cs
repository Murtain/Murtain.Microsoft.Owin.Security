using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Tencent.Wechat.Provider;

namespace Microsoft.Owin.Security.Tencent.Wechat
{
    public class TencentWeChatAuthenticationOptions : AuthenticationOptions
    {
        public TencentWeChatAuthenticationOptions() : base(Constants.DefaultAuthenticationType)
        {
            AuthenticationType = Constants.DefaultAuthenticationType;
            AuthenticationMode = AuthenticationMode.Passive;
            CallbackPath = new PathString(Constants.CallbackPath);
            Caption = Constants.DefaultAuthenticationType;
            Scope = new List<string>
            {
                "snsapi_userinfo"
            };

            TokenEndpoint = Constants.TokenEndpoint;
            UserInformationEndpoint = Constants.UserInformationEndpoint;
            AuthorizationEndpoint = Constants.AuthorizationEndpoint;
        }

        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }
        public PathString CallbackPath { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string SignInAsAuthenticationType { get; set; }
        public string TokenEndpoint { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string UserInformationEndpoint { get; set; }
        public IList<string> Scope { get; }
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }
        public ITencentWeChatAuthenticationProvider Provider { get; set; }

    }
}
