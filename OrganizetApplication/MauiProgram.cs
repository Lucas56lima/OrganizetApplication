using Microsoft.Extensions.Logging;

namespace OrganizetApplication
{
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
                });
            // Adiciona o HttpClient configurado
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7130/api/") });
            builder.Services.AddSingleton<CacheService>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

    }
}
