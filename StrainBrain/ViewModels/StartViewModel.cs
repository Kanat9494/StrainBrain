namespace StrainBrain.ViewModels;

public class StartViewModel : INotifyPropertyChanged
{
    public StartViewModel()
    {
        TryItCommand = new Command(async () => await OnTriedIt());
    }

    public Command TryItCommand { get; }

    private async Task OnTriedIt()
    {
        await Shell.Current.GoToAsync("//Home");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
