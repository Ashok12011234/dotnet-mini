namespace EcommerceMAUI.Views;
using EcommerceMAUI.ViewModel;
public partial class Signup : ContentPage
{
	public Signup()
	{
		InitializeComponent();
        BindingContext = new SignupModel();
    }
}