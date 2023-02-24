namespace StrainBrain.ViewModels;

class HomeViewModel : INotifyPropertyChanged
{
    public HomeViewModel()
    {
        RootMenus = new ObservableCollection<RootMenu>()
        {
            new RootMenu()
            {
                PlayGame = "Играть",
                ExitGame = "Выйти",
            }
        };
    }

    private ObservableCollection<RootMenu> _rootMenus;

    public ObservableCollection<RootMenu> RootMenus
    {
        get => _rootMenus;
        set
        {
            _rootMenus = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
