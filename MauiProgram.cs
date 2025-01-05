using System.Net;
using ECOllect.Database;
using ECOllect.Services;
using ECOllect.ViewModels;

namespace ECOllect;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        DatabaseService.InitializeDatabase();

        var user = new User
        {
            Email = "spaha@gmail.com",
            FirstName = "Ahmed",
            LastName = "Spahic",
            Password = "spaha123",
            Address = "Krivace",
            PhoneNumber = "123456789",
            Points = 560,
            ImageUrl = "spaha.png",
            Role = UserRole.Korisnik
        };
        

        using var connection = DatabaseService.GetConnection();
        connection.Insert(user);
        user=new User
        {
            Email = "semaa@gmail.com",
            FirstName = "Adnan",
            Password="semaa123",
            LastName = "Šemić",
            Address = "Plandiste 120",
            PhoneNumber = "123456789",
            ImageUrl = "sema.png",
            Role = UserRole.Organizator
        };
        connection.Insert(user);
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ActionDetailViewModel>();
        builder.Services.AddTransient<MapViewModel>();

        return builder.Build();
    }
}
