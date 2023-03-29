using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceMAUI.Model.SDK;

namespace EcommerceMAUI.ViewModel
{
    public class LogoutViewModel
    {
        public Command<object> RecommendedTapCommand { get; private set; }
        public LogoutViewModel()
        {
            RecommendedTapCommand = new Command<object>(SelectRecommend);
        }
        private async void SelectRecommend(object obj)
        {
            // Authenticate the user
            //AuthenticationHelper authenticationHelper = new AuthenticationHelper();
            //await authenticationHelper.Login();
            //var accessToken = authenticationHelper.AccessToken;
            await AuthenticationService.logout();
            //IdToken = authenticationHelper.AccessToken;
            //Console.WriteLine(accessToken);
            //IdToken = authenticationHelper.UserInfo;
        }
    }
}
