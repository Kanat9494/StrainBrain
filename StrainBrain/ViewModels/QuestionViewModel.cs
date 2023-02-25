namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuId), nameof(MenuId))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        question = new Question();
        Questions = new ObservableCollection<Question>();
        _questionId++;
        Task.Run(async () =>
        {
            await LoadQuestion();
        }).GetAwaiter().OnCompleted(() =>
        {
            
        });

        //AnswerTapped = new Command<Question>((question) => GetQuestion(question));
        AnswerTapped = new Command<string>((question) => GetQuestion(question));
        TestCommand = new Command<string>(TestAlert);
    }

    Question question;

    public Command AnswerTapped { get; }
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

    private int _rightAnswers;
    public int RightAnswers
    {
        get => _rightAnswers;
        set
        {
            _rightAnswers = value;
            OnPropertyChanged();
        }
    }
    async Task LoadQuestion()
    {
        _questionList = await QuestionService.Instance().GetItemsAsync(0);
        question = _questionList.FirstOrDefault(q => q.QuestionId == _questionId);
        if (question != null)
        {
            QuestionTitle = question.Title;
            ChoiceOne = question.ChoiceOne;
            ChoiceTwo = question.ChoiceTwo;
            ChoiceThree = question.ChoiceThree;
            ChoiceFour = question.ChoiceFour;
            question = null;
        }
        else
        {
            await Shell.Current.DisplayAlert("Технические проблемы", "В данный момент происходит техническое обновление, " +
                "попробуйте позже", "Ок");
        }
    }

    void GetQuestion(string answer)
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
