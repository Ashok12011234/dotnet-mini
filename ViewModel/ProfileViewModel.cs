

using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
//using static UIKit.UIGestureRecognizer;
using System.Net.Http.Headers;

namespace EcommerceMAUI.ViewModel
{
    public class ProfileViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ICommand TapCommand { get; private set; }

        public string Name { get; set; } = "David Spade";
        public string Email { get; set; } = "iamdavid@gmail.com";
        public string ImageUrl { get; set; } = "https://lh3.googleusercontent.com/a-/ACB-R5QQyGv67sQSwpeXl0P3jyn3qM2BsHtQZTsGfOrd=s88-w88-h88-c-k-no";

        public List<MenuItems> _MenuItems = new List<MenuItems>();
        public List<MenuItems> MenuItems
        {
            get { return _MenuItems; }
            set { _MenuItems = value; }
        }

        private string _membership;
        public string Membership
        {
            get { return _membership; }
            set
            {
                _membership = value;
                OnPropertyChanged();
            }
        }
       

        public ProfileViewModel()
        {
            PopulateData();
            CommandInit();
            Membership = "Gold";
            getMembership();
        }

        public async Task getMembership()
        {
            HttpClient HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("accessToken", AuthenticationService.getAccessToken());
            var response = await HttpClient.GetAsync("http://localhost:8070/authorized");
            
            response.EnsureSuccessStatusCode();
            Membership = await response.Content.ReadAsStringAsync();

          

        }
        void PopulateData()
        {
            MenuItems.Clear();
            MenuItems.Add(new Model.MenuItems() { Title = "Wishlist", Body = "\uf2d5", TargetType = typeof(CartPage) });
            MenuItems.Add(new Model.MenuItems() { Title = "Order History", Body = "\uf150", TargetType = typeof(OrderDetails) });
            MenuItems.Add(new Model.MenuItems() { Title = "Notifications", Body = "\uf09c", TargetType = typeof(CartPage) });
        }

        private void CommandInit()
        {
            TapCommand = new Command<MenuItems>(item =>
            {
                Application.Current.MainPage.Navigation.PushModalAsync(((Page)Activator.CreateInstance(item.TargetType)));
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
