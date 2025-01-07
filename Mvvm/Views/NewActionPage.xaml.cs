using ECOllect.Models;
using ECOllect.Mvvm.ViewModels;
using ECOllect.ViewModels;

namespace ECOllect.Views;

public partial class NewActionPage : ContentPage
{
    public NewActionPage()
    {
        InitializeComponent();
        BindingContext = new NewActionViewModel();
    }
}
    