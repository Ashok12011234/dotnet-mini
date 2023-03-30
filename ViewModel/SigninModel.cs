using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//using CoreData;
using EcommerceMAUI.Model.SDK;
using EcommerceMAUI.Views;

namespace EcommerceMAUI.ViewModel
{
    public class SigiinModel : INotifyPropertyChanged
    {
        public Command<object> RecommendedTapCommand { get; private set; }

        private string _idToken;
        public string IdToken
        {
            get { return _idToken; }
            set
            {
                _idToken = value;
                OnPropertyChanged();
            }
        }

        public SigiinModel()
        {
            RecommendedTapCommand = new Command<object>(Authenticate);
            IdToken = "";
        }

        private async void SelectRecommend(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new OrderDetails());
        }

        private async void Authenticate(object obj)
        {

            await AuthenticationService.login();

            if (SessionManager.IsAuthenticated())
            {
                var accessToken = SessionManager.GetCurrentAccessToken();
                IdToken = SessionManager.GetCurrentAccessToken();
                // do something with the access token and user
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
