namespace StrainBrain.ViewModels;

[QueryProperty(nameof(MenuId), nameof(MenuId))]
class QuestionViewModel : INotifyPropertyChanged
{
    public QuestionViewModel()
    {
        question = new Question();
        Questions = new ObservableCollection<Question>();
        _questionId++;
        IsAdvertisement = false;
        IsLoaded = false;
        IsLoading = true;
        RightAnswersCount = 0;
        WrongAnswersCount = 0;
        LoadInterstitial();
        Task.Run(async () =>
        {
            await LoadQuestion();
        }).GetAwaiter().OnCompleted(() =>
        {
            IsLoading = false;
            IsLoaded = true;
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

    private bool _isLoaded;
    public bool IsLoaded
    {
        get => _isLoaded;
        set
        {
            _isLoaded = value;
            OnPropertyChanged();
        }
    }

    private bool _isAdvertisement;
    public bool IsAdvertisement
    {
        get => _isAdvertisement;
        set
        {
            _isAdvertisement = value;
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
            await Shell.Current.DisplayAlert("Вы выиграли", "Вы можете вернуться позже, когда будут доступны " +
                "новые вопросы", "Ок");

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
        }
        else
        {
            await Shell.Current.DisplayAlert("Вы выиграли", "Вы можете вернуться позже, когда будут доступны " +
                "новые вопросы", "Ок");

            //await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync($"..");
        }
    }

    async Task GetQuestion(string answer)
    {
        if (answer != null)
        {
            IsLoaded = false;
            //if (_questionId % 3 == 0)
            //    LoadInterstitial();

            //AdVideo();
            //IsAdvertisement = true;
            //await Task.Delay(2000);
            question = _questionList.FirstOrDefault(q => q.QuestionId == _questionId);
            if (question != null)
            {
                if (question.RightAnswer.Equals(answer))
                {
                    _questionId++;
                    RightAnswersCount++;
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

                    IsAdvertisement = false;
                    IsLoaded = true;
                }
                else
                {
                    _questionId++;
                    WrongAnswersCount++;
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

                    IsAdvertisement = false;
                    IsLoaded = true;
                }
            }
            else
            {
                IsAdvertisement = false;
                IsLoaded = true;
                await LoadQuestion(10);
            }
        }
        else
            return;
    }

    //Загрузка рекламы
    void LoadInterstitial()
    {
        CrossMauiMTAdmob.Current.OnInterstitialLoaded += (s, args) =>
        {
            CrossMauiMTAdmob.Current.ShowInterstitial();
        };

        CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-1407370349507089/6586256314");
    }

    //Не работает
    void AdVideo()
    {
        CrossMauiMTAdmob.Current.OnRewardedLoaded += (s, args) =>
        {
            CrossMauiMTAdmob.Current.ShowRewarded();
        };

        CrossMauiMTAdmob.Current.LoadRewarded("ca-app-pub-3940256099942544/5354046379");
        CrossMauiMTAdmob.Current.ShowRewarded();

        if (CrossMauiMTAdmob.Current.IsRewardedLoaded())
            CrossMauiMTAdmob.Current.ShowRewarded();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
