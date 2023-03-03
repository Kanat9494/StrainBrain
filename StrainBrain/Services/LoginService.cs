namespace StrainBrain.Services;

public class LoginService : ILoginService
{
    public LoginService()
    {
    }

    private static LoginService _instance;
    public static LoginService Instance()
    {
        if (_instance == null)
            _instance = new LoginService();

        return _instance;
    }

    public async Task<UserResponse> AuthenticateUser(string userName, string password)
    {
        LoginRequest loginRequest = new LoginRequest()
        {
            UserName = userName,
            Password = password
        };
        using (HttpClient httpClient = new HttpClient())
        {
            httpClient.BaseAddress = new Uri(StrainBrainConstants.SERVER_ROOT_URL);

            var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
            try
            {
                var response = await httpClient.PostAsync("api/Authentication/AuthenticateUser", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();

                    var authenticatedUser = JsonConvert.DeserializeObject<UserResponse>(jsonResult);


                    return authenticatedUser;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        //try
        //{
        //    var content = new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json");
        //    var response = await httpClient.PostAsync("api/Login/AuthenticateUser", content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var
        //    }
        //}
        //catch (Exception ex)
        //{
        //    return null;
        //}
    }
}
