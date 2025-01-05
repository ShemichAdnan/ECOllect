using ECOllect.Mvvm.ViewModels;
using ECOllect.ViewModels;
using ECOllect.Services;
namespace ECOllect.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterPageViewModel(new MockDataService());
    }
}