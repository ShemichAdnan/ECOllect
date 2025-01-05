﻿using ECOllect.Database;
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

        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<ActionDetailViewModel>();
        builder.Services.AddTransient<MapViewModel>();

        return builder.Build();
    }
}
