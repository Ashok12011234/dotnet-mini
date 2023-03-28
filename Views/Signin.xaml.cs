namespace EcommerceMAUI.Views;
using EcommerceMAUI.ViewModel;
public partial class Signin : ContentPage
{
	public Signin()
	{
		InitializeComponent();
        BindingContext = new SigiinModel();
    }
}