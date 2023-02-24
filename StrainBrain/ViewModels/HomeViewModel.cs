namespace StrainBrain.ViewModels;

class HomeViewModel : INotifyPropertyChanged
{
    public HomeViewModel()
    {
        RootMenus = new ObservableCollection<RootMenu>()
        {
            new RootMenu()
            {
                MenuId = 1,
                MenuTitle = "Играть"
            },
            new RootMenu()
            {
                MenuId = 2,
                MenuTitle = "Выйти"
            }
        };

        ItemTapped = new Command<RootMenu>(OnItemSelected);
    }

    public ObservableCollection<RootMenu> RootMenus { get; set; }

    public Command ItemTapped { get; }

    async void OnItemSelected(RootMenu menu)
    {
        if (menu == null)
            return;

        if (menu.MenuId == 1)
            await Shell.Current.GoToAsync($"{nameof(QuestionPage)}?{nameof(QuestionViewModel.MenuId)}={menu.MenuId}");
        else if (menu.MenuId == 2)
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
