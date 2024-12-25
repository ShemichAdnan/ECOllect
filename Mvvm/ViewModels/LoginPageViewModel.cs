using System.Windows.Input;
using ECOllect.Services;
using ECOllect.Views;

namespace ECOllect.ViewModels;

public class LoginPageViewModel : BaseViewModel
{
    private readonly IDataService _dataService;
    private string _email;
    private string _password;

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public ICommand LoginCommand { get; }
    public ICommand NavigateToRegisterCommand { get; }

    public LoginPageViewModel(IDataService dataService)
    {
        _dataService = dataService;
        LoginCommand = new Command(async () => await LoginAsync());
        NavigateToRegisterCommand = new Command(async () => await NavigateToRegister());
    }

    private async Task LoginAsync()
    {
        
        
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Molimo unesite email i lozinku", "OK");
                return;
            }

            var user = await _dataService.LoginUser(Email, Password);
            if (user != null)
            {
                App.CurrentUser = user;
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešan email ili lozinka", "OK");
            }
        
        
    }

    private async Task NavigateToRegister()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
    }
}