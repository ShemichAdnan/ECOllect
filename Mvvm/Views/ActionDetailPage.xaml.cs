using ECOllect.Models;
using ECOllect.ViewModels;

namespace ECOllect.Views;

public partial class ActionDetailPage : ContentPage
{
    public ActionDetailPage(CommunityAction action)
    {
        InitializeComponent();
        BindingContext = new ActionDetailViewModel(action);
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Navigate back to the previous page
    }
}
    