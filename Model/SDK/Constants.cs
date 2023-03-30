using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI.Model.SDK
{
    /// <summary>
    /// A collection of all constants.
    /// </summary>
    public class Constants
    {
        private const string clientId = "ClientId";
        private const string clientSecret = "ClientSecret";
        private const string authorizationEndpoint = "AuthorizationEndpoint";
        private const string tokenEndpoint = "TokenEndpoint";
        private const string introspectionEndpoint = "IntrospectionEndpoint";
        private const string userInfoEndpoint = "UserInfoEndpoint";
        private const string logoutEndpoint = "LogoutEndpoint";
        private const string redirectURI = "RedirectURI";
        private const string postLogoutRedirectURI = "PostLogoutRedirectURI";
        private const string codeChallengeMethod = "S256";
        private const string authorizationRequest = "{0}?response_type=code&scope=openid%20profile&" +
                "redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}";
        private const string responseString = "<html><head><meta http-equiv='refresh' content='10;" +
                "url=https://google.com'></head><body>Please close the browser and return to the app.</body></html>";
        private const string code = "code";
        private const string state = "state";
        private const string tokenRequestBody = "code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}" +
                "&client_secret={4}&scope=&grant_type=authorization_code";
        private const string methodPost = "POST";
        private const string methodGet = "GET";
        private const string contentType = "application/x-www-form-urlencoded";
        private const string accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        private const string postRedirectURI = "{0}?id_token_hint={1}&post_logout_redirect_uri={2}";

        public static string ClientId => clientId;
        public static string ClientSecret => clientSecret;
        public static string AuthorizationEndpoint => authorizationEndpoint;
        public static string TokenEndpoint => tokenEndpoint;
        public static string IntrospectionEndpoint => introspectionEndpoint;
        public static string UserInfoEndpoint => userInfoEndpoint;
        public static string LogoutEndpoint => logoutEndpoint;
        public static string RedirectURI => redirectURI;
        public static string PostLogoutRedirectURI => postLogoutRedirectURI;
        public static string AuthorizationRequest => authorizationRequest;
        public static string ResponseString => responseString;
        public static string TokenRequestBody => tokenRequestBody;
        public static string Code => code;
        public static string State => state;
        public static string MethodPost => methodPost;
        public static string MethodGet => methodGet;
        public static string ContentType => contentType;
        public static string Accept => accept;
        public static string CodeChallengeMethod => codeChallengeMethod;
        public static string PostRedirectURI => postRedirectURI;
    }
}
