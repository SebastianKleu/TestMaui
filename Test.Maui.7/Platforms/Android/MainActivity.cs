using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Maui._7.Services;

namespace Test.Maui._7;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        var app = IPlatformApplication.Current ??
                  throw new InvalidOperationException("IPlatformApplication.Current is null");
        //Ensure DB is created
        var _dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<TestDataContext>>();
        DbInitialiser.Initialise(_dbContextFactory.CreateDbContext());


        if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            StartForegroundService(new Intent(this, typeof(TesterService)));
        else
            StartService(new Intent(this, typeof(TesterService)));
    }
}