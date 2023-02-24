namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuTitle), nameof(MenuTitle))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        test = _menuTitle;
        TestCommand = new Command<string>(TestAlert);
    }

    public Command TestCommand { get; }

    public async void TestAlert(string menuTitle)
    {
        await Shell.Current.DisplayAlert("Тестовый алерт", MenuTitle, "Ок");
    }

    string test = "";
    private string _menuTitle;

    public string MenuTitle
    {
        get => _menuTitle;
        set
        {
            _menuTitle = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
