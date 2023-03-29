

using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.ComponentModel;
using System.Windows.Input;

using System.Text.Json.Nodes;
using System.IdentityModel.Tokens.Jwt;


namespace EcommerceMAUI.ViewModel
{
    public class ProfileViewModel : BaseViewModel, INotifyPropertyChanged
    {
        //JwtSecurityToken IdToken = AuthenticationService.getUserInfo();
        public ICommand TapCommand { get; private set; }


        public string Name { get; set; } = AuthenticationService.getUserInfo().Claims.First(claim => claim.Type == "given_name").Value.ToString();

        public string Email { get; set; } = AuthenticationService.getUserInfo().Claims.First(claim => claim.Type == "email").Value.ToString();
        public string ImageUrl { get; set; } = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";


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
