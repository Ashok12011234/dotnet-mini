using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMAUI
{
    internal class SessionManager
    {
        private static string _currentAccessToken;
        private static string _currentUser;

        public static void SetSession(string accessToken, string currentUser)
        {
            _currentAccessToken = accessToken;
            _currentUser = currentUser;
        }

        public static void ClearSession()
        {
            _currentAccessToken = null;
            _currentUser = null;
        }

        public static bool IsAuthenticated()
        {
            return !string.IsNullOrEmpty(_currentAccessToken) && !string.IsNullOrEmpty(_currentUser);
        }

        public static string GetCurrentAccessToken()
        {
            return _currentAccessToken;
        }

        public static string GetCurrentUser()
        {
            return _currentUser;
        }
    }
}
