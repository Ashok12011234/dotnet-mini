namespace EcommerceMAUI.Views;

public partial class Logout : ContentPage
{
	public Logout()
	{
		InitializeComponent();
	}

    private async void OnLogoutClicked(object sender, EventArgs e)

    {

        await AuthenticationService.logout();

        await Navigation.PushAsync(new Signin());
    }
}