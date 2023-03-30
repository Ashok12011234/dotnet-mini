

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
            BestSellingDataList.Add(new ProductListModel() { Name = "Apple Iphone 14 Pro", BrandName = "Apple", Price = "$755", ImageUrl = "https://cellucity.co.za/wp-content/uploads/2022/09/Apple-iPhone-14-Pro-Max-5G-Deep-Purple.jpg" });
            BestSellingDataList.Add(new ProductListModel() { Name = "Google Pixel 7 Pro", BrandName = "Google", Price = "$450", ImageUrl = "https://lh3.googleusercontent.com/2QKYQg6WuyEbx0Kd83N8-_lhs0Vk-GYQWCqsQjtuGejiimGFRTp-FEc9tDfMer_xoj7FaOMuAE7pg0Uj-rpWS9A2RpZiCQpZSXi3=rw-e365-w1050" });
            BestSellingDataList.Add(new ProductListModel() { Name = "Samsung galaxy S23 Ultra", BrandName = "Samsung", Price = "$900", ImageUrl = "https://cdn.vox-cdn.com/uploads/chorus_asset/file/24396788/DSC04113_processed.jpg" });
            BestSellingDataList.Add(new ProductListModel() { Name = "One Plus 11 5G", BrandName = "Google", Price = "$1200", ImageUrl = "https://fdn.gsmarena.com/imgroot/news/23/01/oneplus-11-ofic/inline/-1200/gsmarena_001.jpg" });
        }

        
        private async void SelectProduct(ProductListModel obj)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ProductDetails());
        }

       
        
    }
}
