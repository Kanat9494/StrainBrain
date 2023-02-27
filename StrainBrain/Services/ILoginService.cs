namespace StrainBrain.Services;

public interface ILoginService
{
    Task<UserResponse> AuthenticateUser(string userName, string password);
}
