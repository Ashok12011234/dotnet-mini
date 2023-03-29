//using CoreMidi;
using EcommerceMAUI.Model.SDK;
namespace EcommerceMAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // add main page
        builder.Services.AddSingleton<AuthenticationService>();

        // setup OidcClient
        builder.Services.AddSingleton(new AuthenticationHelper());

        return builder.Build();
    }
}
