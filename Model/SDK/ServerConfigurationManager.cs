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
    public class ServerConfigurationManager
    {
        // Declare an instance for log4net.
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.
            GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Check missing values in <AppSettings> in 'app.config' file.
        /// </summary>
        /// <returns> Boolean true if the configuration details are empty, false if else. </returns>
        public static Boolean IsEmpty()
        {
            ServerConfiguration config = new ServerConfiguration();
            if (config.ClientId == "" || config.ClientSecret == "" || config.AuthorizationEndpoint == "" ||
                config.TokenEndpoint == "" || config.UserInfoEndpoint == "" || config.LogoutEndpoint == "" ||
                config.RedirectUri == "" || config.PostLogoutRedirectUri == "")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update <AppSettings> in 'app.config' file.
        /// </summary>
        /// <param name="key"> Refers to <AppSettings>s' key in 'app.config' file. </param>
        /// <param name="value"> Refers to <AppSettings>s' value in 'app.config' file. </param>
        public static void UpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception)
            {
                Log.Info("Error writing app settings");
            }
        }

        /// <summary>
        /// Enable ssl veification to establish trust relationship for the SSL/TLS secure channel.
        /// </summary>
        public void EnableSSLverification()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate
                certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        }
    }
}
