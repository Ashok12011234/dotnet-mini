using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceMAUI.Model.SDK;
using EcommerceMAUI.Views;

namespace EcommerceMAUI.ViewModel
{
    public class SigiinModel
    {
        public Command<object> RecommendedTapCommand { get; private set; }
        public Command<object> AuthenticateTapCommand { get; private set; }
        public SigiinModel()
        {
            RecommendedTapCommand = new Command<object>(SelectRecommend);
            AuthenticateTapCommand = new Command<object>(Authenticate);
        }
        private async void SelectRecommend(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OrderDetails());
        }

        private async void Authenticate(object obj)
        {
            // Authenticate the user
            AuthenticationHelper authenticationHelper = new AuthenticationHelper();
            await authenticationHelper.Login();
            var accessToken = authenticationHelper.AccessToken;
            Console.WriteLine(accessToken);
        }
    }
}
