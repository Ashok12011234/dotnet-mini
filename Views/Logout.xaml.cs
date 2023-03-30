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

        // Create a new instance of the AppShell
        var newShell = new AppShell();

        // Set the new Shell as the MainPage of the Application
        Application.Current.MainPage = newShell;
    }
}