namespace StrainBrain.ViewModels;

class HomeViewModel : INotifyPropertyChanged
{
    public HomeViewModel()
    {
        RootMenus = new ObservableCollection<RootMenu>()
        {
            new RootMenu()
            {
                MenuTitle = "Играть"
            },
            new RootMenu()
            {
                MenuTitle = "Выйти"
            }
        };

        ItemTapped = new Command<RootMenu>()
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

    public Command ItemTapped { get; }

    async Task OnItemSelected(RootMenu menu)
    {
        if (menu == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(QuestionPage)}?{nameof(QuestionViewModel.MenuTitle)}={menu.MenuTitle}");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
