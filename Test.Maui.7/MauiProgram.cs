using Microsoft.Extensions.Logging;
using Test.Data.Extensions;
using Test.Maui._7.Services;


namespace Test.Maui._7
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IServiceNotification, ServiceNotification>();
            builder.Services.AddSingleton<IDbTester, DbTester>();


            builder.Services.AddEntityFramework();
            return builder.Build();
        }
    }
}
