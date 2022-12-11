using Microsoft.Extensions.Logging;
using StudentsRecords.Contracts.Services;
using StudentsRecords.Platforms.Android;
using StudentsRecords.Services;
using StudentsRecords.ViewModels;

namespace StudentsRecords;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<AddStudent>();
        builder.Services.AddTransient<AddStudentViewModel>();
        builder.Services.AddTransient<EditStudent>();
        builder.Services.AddTransient<EditStudentViewModel>();
        builder.Services.AddTransient<Views.AboutPage>();
        builder.Services.AddTransient<AboutPageViewModel>();
        builder.Services.AddTransient<Views.SupportPage>();
        builder.Services.AddTransient<SupportPageViewModel>();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        return builder.Build();
    }
}

