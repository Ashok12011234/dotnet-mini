using System;
using log4net;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace EcommerceMAUI.Model.SDK
{
    /// <summary>
    /// Manage all server configurations.
    /// </summary>
    public class ServerConfiguration
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string IntrospectionEndpoint { get; set; }
        public string UserInfoEndpoint { get; set; }
        public string LogoutEndpoint { get; set; }
        public string RedirectUri { get; set; }
        public string PostLogoutRedirectUri { get; set; }

        /// <summary>
        /// Retrieves data to the frontend from 'app.config' file.
        /// </summary>
        public ServerConfiguration()
        {
            this.ClientId = ConfigurationManager.AppSettings[Constants.ClientId];
            this.ClientSecret = ConfigurationManager.AppSettings[Constants.ClientSecret];
            this.AuthorizationEndpoint = ConfigurationManager.AppSettings[Constants.AuthorizationEndpoint];
            this.TokenEndpoint = ConfigurationManager.AppSettings[Constants.TokenEndpoint];
            this.IntrospectionEndpoint = ConfigurationManager.AppSettings[Constants.IntrospectionEndpoint];
            this.UserInfoEndpoint = ConfigurationManager.AppSettings[Constants.UserInfoEndpoint];
            this.LogoutEndpoint = ConfigurationManager.AppSettings[Constants.LogoutEndpoint];
            this.RedirectUri = ConfigurationManager.AppSettings[Constants.RedirectURI];
            this.PostLogoutRedirectUri = ConfigurationManager.AppSettings[Constants.PostLogoutRedirectURI];
        }
    }
}
