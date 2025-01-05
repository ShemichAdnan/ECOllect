
using ECOllect.Database;
using ECOllect.Mvvm.Models;
using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ECOllect.Services;
using ECOllect.ViewModels;
using ECOllect.Views;
using User = ECOllect.Database.User;

namespace ECOllect.Mvvm.ViewModels
{
    public class RegisterPageViewModel : BaseViewModel
    {
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

        public RegisterPageViewModel(MockDataService mockDataService)
        {
            RegisterCommand = new Command(async () => await RegisterAsync());
            BackToLoginCommand = new Command(async () => await NavigateToLogin());
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

            // Regex checks for input fields

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(Email, emailPattern))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email nije validan", "OK");
                return;
            }

            string passwordPattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (!Regex.IsMatch(Password, passwordPattern))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinka mora imati najmanje 8 karaktera, jedno slovo, jedan broj i jedan specijalni znak", "OK");
                return;
            }

            if (Password != ConfirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju", "OK");
                return;
            }

            string phonePattern = @"^\+?[1-9]\d{1,14}$";
            if (!Regex.IsMatch(PhoneNumber, phonePattern))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Broj telefona nije validan", "OK");
                return;
            }

            var user = new User
            {
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Password = Password
            };


            using var connection = DatabaseService.GetConnection();
            
            var existingUser = connection.Table<User>().FirstOrDefault(u => u.Email == Email);
            if (existingUser != null)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Taj email je vec registrovan", "OK");
                return;
            }
            
            connection.Insert(user);

            await Application.Current.MainPage.DisplayAlert("Uspješno", "Registracija uspješna", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        
        private async Task NavigateToLogin()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
