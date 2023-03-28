

using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }

        public string Name { get; set; } = "David Spade";
        public string Email { get; set; } = "iamdavid@gmail.com";
        public string ImageUrl { get; set; } = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";

        public List<MenuItems> _MenuItems = new List<MenuItems>();
        public List<MenuItems> MenuItems
        {
            get { return _MenuItems; }
            set { _MenuItems = value; }
        }

        public ProfileViewModel()
        {
            PopulateData();
            CommandInit();
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
    }
}
