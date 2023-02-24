namespace StrainBrain.Services;

public interface IAppServiceProvider<T>
{
    Task<IEnumerable<T>> GetItemsAsync();
}
