namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuId), nameof(MenuId))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        question = new Question();
        Questions = new ObservableCollection<Question>();
        _questionId++;
        IsLoading = true;
        Task.Run(async () =>
        {
            await LoadQuestion();
        }).GetAwaiter().OnCompleted(() =>
        {
            
        });

        //AnswerTapped = new Command<Question>((question) => GetQuestion(question));
        AnswerTapped = new Command<string>(async (question) => await GetQuestion(question));
        TestCommand = new Command(TestAlert);
    }

    Question question;

    public Command AnswerTapped { get; }
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

    //Информация для пользователя
    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    private int _questionsCount;
    public int QuestionsCount
    {
        get => _questionsCount;
        set
        {
            _questionsCount = value;
            OnPropertyChanged();
        }
    }

    private int _rightAnswersCount;
    public int RightAnswersCount
    {
        get => _rightAnswersCount;
        set
        {
            _rightAnswersCount = value;
            OnPropertyChanged();
        }
    }

    private int _wrongAnswersCount;
    public int WrongAnswersCount
    {
        get => _wrongAnswersCount;
        set
        {
            _wrongAnswersCount = value;
            OnPropertyChanged();
        }
    }

    // Вопросы и варианты ответов
    public ObservableCollection<Question> Questions { get; set; }

    private int _questionId = 0;

    private string _questionTitle;
    public string QuestionTitle
    {
        get => _questionTitle;
        set
        {
            _questionTitle = value;
            OnPropertyChanged();
        }
    }

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

    // Список вопросов
    private IEnumerable<Question> _questionList;

    async Task LoadQuestion(int questionsCountToSkip = 0)
    {
        _questionList = await QuestionService.Instance().GetItemsAsync(questionsCountToSkip);
        if (_questionList == null)
        {
            await Shell.Current.DisplayAlert("Технические проблемы", "В данный момент происходит техническое обновление, " +
                "попробуйте позже", "Ок");

            //await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync($"..");
        }
        question = _questionList.FirstOrDefault(q => q.QuestionId == _questionId);
        if (question != null)
        {
            QuestionTitle = question.Title;
            ChoiceOne = question.ChoiceOne;
            ChoiceTwo = question.ChoiceTwo;
            ChoiceThree = question.ChoiceThree;
            ChoiceFour = question.ChoiceFour;
            question = null;

            IsLoading = false;
        }
        else
        {
            IsLoading = false;
            await Shell.Current.DisplayAlert("Технические проблемы", "В данный момент происходит техническое обновление, " +
                "попробуйте позже", "Ок");

            //await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync($"..");
        }
    }

    async Task GetQuestion(string answer)
    {
        if (answer != null)
        {
            question = _questionList.FirstOrDefault(q => q.QuestionId == _questionId);
            if (question != null)
            {
                if (question.RightAnswer.Equals(answer))
                {
                    _questionId++;
                    question = null;
                    question = _questionList.FirstOrDefault(q => q.QuestionId == _questionId);
                    if (question != null)
                    {
                        QuestionTitle = question.Title;
                        ChoiceOne = question.ChoiceOne;
                        ChoiceTwo = question.ChoiceTwo;
                        ChoiceThree = question.ChoiceThree;
                        ChoiceFour = question.ChoiceFour;
                    }
                }
            }
            else
            {
                await LoadQuestion(10);
            }
        }
        else
            return;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
