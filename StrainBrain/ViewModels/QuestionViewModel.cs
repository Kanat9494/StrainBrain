namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuId), nameof(MenuId))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        TestCommand = new Command<string>(TestAlert);

        ChoiceOne = "Тест вариант";
    }

    public Command TestCommand { get; }

    public async void TestAlert(string choice)
    {
        await Shell.Current.DisplayAlert("Тестовый алерт", choice, "Ок");
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

    // Вопросы и варианты ответов
    private string _issue;
    public string Issue
    {
        get => _issue;
        set
        {
            _issue = value;
            OnPropertyChanged();
        }
    }

    private string _choiceOne;
    public string ChoiceOne
    {
        get => _choiceOne;
        set
        {
            _choiceOne = value;
            OnPropertyChanged();
        }
    }

    private string _choiceTwo;
    public string ChoiceTwo
    {
        get => _choiceTwo;
        set
        {
            _choiceTwo = value;
            OnPropertyChanged();
        }
    }

    private string _choiceThree;
    public string ChoiceThree
    {
        get => _choiceThree;
        set
        {
            _choiceThree = value;
            OnPropertyChanged();
        }
    }

    private string _choiceFour;
    public string ChoiceFour
    {
        get => _choiceFour;
        set
        {
            _choiceFour = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
