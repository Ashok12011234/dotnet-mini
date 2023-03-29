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

    }

    public static async Task logout()
    {
        await authenticationHelper.Logout(_currentAccessToken);
        //var request = authenticationHelper.Request;
    }

    public static string getAccessToken()

    {
       // _currentAccessToken = authenticationHelper.AccessToken;
        return _currentAccessToken;

    }

    public static string getUser()
    {
        var userInfo = authenticationHelper.UserInfo;
        dynamic json = JsonConvert.DeserializeObject(userInfo);
        var subject = json.sub;
        return subject;
    }

    public static JwtSecurityToken getUserInfo()
    {
        var accessToken = _currentAccessToken;
        dynamic accessJson = JsonConvert.DeserializeObject(accessToken);
        var idToken = accessJson.id_token;

        string stream = idToken;
        var handler = new JwtSecurityTokenHandler();
        var jsonToken = handler.ReadJwtToken(stream);

        return jsonToken;
    }


}
