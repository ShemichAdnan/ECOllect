
using ECOllect.Database;
using ECOllect.Mvvm.Models;
using System;
using System.Linq;
using System.Windows.Input;
using ECOllect.Services;
using ECOllect.ViewModels;
using ECOllect.Views;
using User = ECOllect.Database.User;

namespace ECOllect.Mvvm.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
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

        public LoginPageViewModel(MockDataService mockDataService)
        {
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
        
            using var connection = DatabaseService.GetConnection();
            var allUsers = connection.Table<User>().ToList();
            Console.WriteLine("Current Users in Table:");
            foreach (var userL in allUsers)
            {
                Console.WriteLine($"Id: {userL.Id}, Email: {userL.Email}, FirstName: {userL.FirstName}, LastName: {userL.LastName}, Password: {userL.Password}");
            }
            var user = connection.Table<User>().FirstOrDefault(u => u.Email == Email && u.Password == Password);

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
}
