
using ECOllect.Database;
using ECOllect.Mvvm.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ECOllect.Models;
using ECOllect.Services;
using ECOllect.ViewModels;
using ECOllect.Views;

namespace ECOllect.Mvvm.ViewModels
{
    public class NewActionViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private string _location;
        private string _latitude;
        private string _longitude;
        private string _participants;
        private string _prize;
        private string _image;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public string Location
        {
            get => _location;
            set => SetProperty(ref _location, value);
        }

        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        public string Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        public string Participants
        {
            get => _participants;
            set => SetProperty(ref _participants, value);
        }

        public string Prize
        {
            get => _prize;
            set => SetProperty(ref _prize, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public ICommand AddActionCommand { get; }
        public ICommand GoBackCommand { get; }

        public NewActionViewModel()
        {
            AddActionCommand = new Command(async () => await AddActionAsync());
            GoBackCommand = new Command(async () => await GoBack());
        }

        private async Task AddActionAsync()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Location) || string.IsNullOrWhiteSpace(Latitude.ToString()) || string.IsNullOrWhiteSpace(Longitude.ToString()) || Convert.ToInt32(Prize) <= 0 || string.IsNullOrWhiteSpace(Image))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Molimo unesite sve podatke", "OK");
                return;
            }

            using var connection = DatabaseService.GetConnection();
            var action = new CommunityAction
            {
                Title = Title,
                Description = Description,
                Date = Date,
                Location = Location,
                Latitude = Convert.ToDouble(Latitude),
                Longitude = Convert.ToDouble(Longitude),
                Participants = Convert.ToInt32(Participants),
                Prize = Convert.ToInt32(Prize),
                Image = Image
            };
            connection.Insert(action);
            await Application.Current.MainPage.DisplayAlert("Success", "Uspješno ste dodali akciju", "OK");
            Application.Current.MainPage = new NavigationPage(new HomePage());
        }

        private async Task GoBack()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
