//using CoreMidi;
using EcommerceMAUI.Model.SDK;
using log4net;

namespace EcommerceMAUI;

public static class MauiProgram
{
    static ILog log = LogManager.GetLogger(typeof(MauiProgram));
    public static MauiApp CreateMauiApp()
    {
        //FileInfo fi = new FileInfo("log4net.config");
        log4net.Config.XmlConfigurator.Configure();

        log.Info("Hello hasini world!");

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
