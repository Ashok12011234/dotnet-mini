using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceMAUI.Views;
namespace EcommerceMAUI.ViewModel
{
    public class SignupModel
    {
        public Command<object> RecommendedTapCommand { get; private set; }
        public SignupModel() {
            RecommendedTapCommand = new Command<object>(SelectRecommend);
        }
        private async void SelectRecommend(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OrderDetails());
        }
    }
}
