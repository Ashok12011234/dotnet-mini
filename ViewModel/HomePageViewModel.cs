

using EcommerceMAUI.Model;
using EcommerceMAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EcommerceMAUI.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand TapCommand { get; private set; }
        public ICommand BrandTapCommand { get; private set; }
        public ICommand CategoryTapCommand { get; private set; }

        public ObservableCollection<CategoriesModel> _CategoriesDataList = new ObservableCollection<CategoriesModel>();
        public ObservableCollection<CategoriesModel> CategoriesDataList
        {
            get
            {
                return _CategoriesDataList;
            }
            set
            {
                _CategoriesDataList = value;
                OnPropertyChanged("CategoriesDataList");
            }
        }

        public ObservableCollection<ProductListModel> _BestSellingDataList = new ObservableCollection<ProductListModel>();
        public ObservableCollection<ProductListModel> BestSellingDataList
        {
            get
            {
                return _BestSellingDataList;
            }
            set
            {
                _BestSellingDataList = value;
                OnPropertyChanged("BestSellingDataList");
            }
        }

        

        public HomePageViewModel()
        {
            PopulateData();
            TapCommand = new Command<ProductListModel>(SelectProduct);
        }
        void PopulateData()
        {
            CategoriesDataList.Clear();
            CategoriesDataList.Add(new CategoriesModel() { CategoryID = 2, CategoryName = "Devices", Icon = "\uf322" });
            CategoriesDataList.Add(new CategoriesModel() { CategoryID = 2, CategoryName = "Services", Icon = "\uf2cb" });

            BestSellingDataList.Clear();
            BestSellingDataList.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = "$755", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
            BestSellingDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = "$450", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
            BestSellingDataList.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = "$900", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
            BestSellingDataList.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = "$1200", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
        }

        
        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

       
        
    }
}
