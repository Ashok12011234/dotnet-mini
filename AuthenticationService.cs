//using CoreMidi;
using System.IdentityModel.Tokens.Jwt;
using EcommerceMAUI.Model.SDK;
using Newtonsoft.Json;
namespace EcommerceMAUI;

public partial class AuthenticationService
{
  
    private static string _currentAccessToken;
    private static AuthenticationHelper authenticationHelper;

    public AuthenticationService(AuthenticationHelper _authenticationHelper)
    {

        authenticationHelper = _authenticationHelper;
    }

    public static async Task login()
    {
        authenticationHelper = new AuthenticationHelper();
        await authenticationHelper.Login();
        _currentAccessToken = authenticationHelper.AccessToken;
        var currentUser = getUserInfo();
        SessionManager.SetSession(_currentAccessToken, currentUser);

    }

    public static async Task logout()
    {
        if (SessionManager.IsAuthenticated())
        {
            await authenticationHelper.Logout(_currentAccessToken);
            SessionManager.ClearSession();
        }
    }

    public static string getUser()
    {
        var userInfo = authenticationHelper.UserInfo;
        dynamic json = JsonConvert.DeserializeObject(userInfo);
        var subject = json.sub;
        return subject;
    }

    public static string getUserInfo()
    {
        var accessToken = _currentAccessToken;
        dynamic accessJson = JsonConvert.DeserializeObject(accessToken);
        var userInfo = authenticationHelper.UserInfo;
        dynamic userJson = JsonConvert.DeserializeObject(userInfo);
        var idToken = accessJson.id_token;

        string stream = idToken;
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(stream);

        return jsonToken.ToString();
    }

    public static async Task<bool> isTokenValidAsync()
    {
        var accessToken = _currentAccessToken;
        return await authenticationHelper.IsTokenValid(accessToken);
    }


}
