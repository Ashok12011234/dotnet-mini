namespace EcommerceMAUI.Views;

//using CoreData;
using EcommerceMAUI.ViewModel;
public partial class Signin : ContentPage
{
	public Signin()
	{
		InitializeComponent();
        BindingContext = new SigiinModel();
    }

    private async void OnLoginClicked(object sender, EventArgs e)

    {
      
        //await AuthenticationService.login();


    }


    }