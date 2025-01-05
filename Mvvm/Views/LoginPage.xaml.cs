using ECOllect.Mvvm.ViewModels;
using ECOllect.ViewModels;
using ECOllect.Services;
namespace ECOllect.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginPageViewModel(new MockDataService());
    }
}