namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuId), nameof(MenuId))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        TestCommand = new Command(TestAlert);
    }

    public Command TestCommand { get; }

    public async void TestAlert()
    {
        await Shell.Current.DisplayAlert("Тестовый алерт", "", "Ок");
    }

    string testString = "";
    private string _menuId;

    public string MenuId
    {
        get => _menuId;
        set
        {
            _menuId = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
