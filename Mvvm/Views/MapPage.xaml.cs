using ECOllect.Models;
using ECOllect.ViewModels;

namespace ECOllect.Views;

public partial class MapPage : ContentPage
{
    private readonly MapViewModel _viewModel;

    public MapPage()
    {
        InitializeComponent();
        _viewModel = new MapViewModel();
        BindingContext = _viewModel;

        // Set the HTML source directly
        mapWebView.Source = new HtmlWebViewSource
        {
            Html = _viewModel.MapHtml
        };
        mapWebView.Navigating += WebView_Navigating;
        SetupWebView();
    }

    private void SetupWebView()
    {
        mapWebView.Navigating += WebView_Navigating;
    }

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        if (e.Url?.StartsWith("hybrid:") == true)
        {
            e.Cancel = true;
            var data = e.Url.Substring("hybrid:".Length);

            if (data.StartsWith("openAction:"))
            {
                var idString = data.Substring("openAction:".Length);
                if (int.TryParse(idString, out int actionId) && actionId >= 0 && actionId < _viewModel.Actions.Count)
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        var selectedAction = _viewModel.Actions[actionId];
                        await Navigation.PushAsync(new ActionDetailPage(selectedAction));
                    });
                }
            }
        }
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}