namespace StrainBrain.ViewModels;

class LoginViewModel : INotifyPropertyChanged
{
    public LoginViewModel()
    {
        IsLoading = false;
        LoginCommand = new Command(async () => await OnLogin());
    }

    public Command LoginCommand { get; }

    async Task OnLogin()
    {
        IsLoading = true;
        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
        {
            await Shell.Current.DisplayAlert("Пустые значения", "Пожалуйста введите логин и пароль для входа в систему!", "Ок");
            IsLoading = false;
        }
        else
        {
            CurrentUser = await LoginService.Instance().AuthenticateUser(userName: UserName, password: Password);

            if (CurrentUser == null)
            {
                await Shell.Current.DisplayAlert("Не удалоись войти в систему", "Пожалуйста, введите правильные данные", "Ок");
                IsLoading = false;
            }
            else
            {
                await Shell.Current.GoToAsync("//Home");
            }
        }
    }

    private UserResponse _currentUser;
    public UserResponse CurrentUser
    {
        get => _currentUser;
        set
        {
            _currentUser = value;
            OnPropertyChanged();
        }
    }

    private string _userName;
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value;
            OnPropertyChanged();
        }
    }

    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
