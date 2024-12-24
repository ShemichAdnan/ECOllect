using ECOllect.Models;

namespace ECOllect.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.HomeViewModel();
    }

    private async void OnActionTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is CommunityAction action)
        {
            await Navigation.PushAsync(new ActionDetailPage(action));
        }
    }
    private async void OnMapButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MapPage());
    }
}
