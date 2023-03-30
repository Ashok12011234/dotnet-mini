using EcommerceMAUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
           
            //await AuthenticationService.logout();
            //await Application.Current.MainPage.Navigation.PushModalAsync(new Signin());

        }
    }
}
