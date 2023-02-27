namespace StrainBrain.Services;

public interface ILoginService
{
    Task Login(string userName, string password);
}
