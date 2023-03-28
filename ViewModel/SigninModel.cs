using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            // Authenticate the user
            AuthenticationHelper authenticationHelper = new AuthenticationHelper();
            await authenticationHelper.Login();
            var accessToken = authenticationHelper.AccessToken;
            IdToken = authenticationHelper.AccessToken;
            //Console.WriteLine(accessToken);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
