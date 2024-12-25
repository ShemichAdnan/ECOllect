using System.Windows.Input;
using ECOllect.Models;
using ECOllect.Services;

namespace ECOllect.ViewModels;

public class RegisterPageViewModel : BaseViewModel
{
    private readonly IDataService _dataService;

    private string _firstName;
    private string _lastName;
    private string _email;
    private string _phoneNumber;
    private string _address;
    private string _password;
    private string _confirmPassword;

    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public string Email
    {
        get => _email;
        set => SetProperty(ref _email, value);
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetProperty(ref _phoneNumber, value);
    }

    public string Address
    {
        get => _address;
        set => SetProperty(ref _address, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => SetProperty(ref _confirmPassword, value);
    }

    public ICommand RegisterCommand { get; }
    public ICommand BackToLoginCommand { get; }

    public RegisterPageViewModel(IDataService dataService)
    {
        _dataService = dataService;
        RegisterCommand = new Command(async () => await RegisterAsync());
        BackToLoginCommand = new Command(async () => await BackToLogin());
    }

    private async Task RegisterAsync()
    {
        
        
            if (string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword) ||
                string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(PhoneNumber) ||
                string.IsNullOrWhiteSpace(Address))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Molimo popunite sva polja", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju", "OK");
                return;
            }

            var user = new User
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Address = Address
            };

            var success = await _dataService.RegisterUser(user, Password);
            if (success)
            {
                await Application.Current.MainPage.DisplayAlert("Uspješno", "Registracija uspješna", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email već postoji", "OK");
            }
        
        
    }

    private async Task BackToLogin()
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}