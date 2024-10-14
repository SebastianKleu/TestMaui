using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Maui._8.Services;

[Service(Name = "com.maui.eight", Exported = true)]
public class TesterService : Service
{
    private readonly IServiceNotification _serviceNotification;

    private const int ServiceRunningNotificationId = 10008;
    private readonly IDbTester _dbTester;
    private IDbContextFactory<TestDataContext> _dbContextFactory;

    public TesterService()
    {
        var app = IPlatformApplication.Current ??
                  throw new InvalidOperationException("IPlatformApplication.Current is null");
        _serviceNotification = app.Services.GetRequiredService<IServiceNotification>();

        _dbContextFactory = app.Services.GetRequiredService<IDbContextFactory<TestDataContext>>();

        _dbTester = app.Services.GetRequiredService<IDbTester>();
    }

    public override IBinder? OnBind(Intent? intent)
    {
        return null;
    }

    public override void OnCreate()
    {
        base.OnCreate();

        try
        {
            var notification = _serviceNotification.ReturnNotification("Test service 8", "Net 8 Service running");

            StartForeground(ServiceRunningNotificationId, notification);
        }
        catch (Exception ex)
        {
            Log.Error("TesterService", "Error creating notification:", ex);
        }
    }


    public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
    {
        base.OnStartCommand(intent, flags, startId);

        DbInitialiser.Initialise(_dbContextFactory.CreateDbContext());

        _dbTester.TestDb();

        // It has been killed by Android, and now it is restarted. We must make sure to have re-initialised everything
        if (intent != null) return StartCommandResult.Sticky;


        return StartCommandResult.Sticky;
    }
}