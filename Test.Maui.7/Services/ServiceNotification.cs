#region Imports

using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.Core.App;
using Test.Maui._7;

#endregion

namespace Test.Maui._7.Services;

/// <inheritdoc />
internal class ServiceNotification : IServiceNotification
{
    private const string ForegroundChannelId = "net7Id";
    private static readonly Context Context = Android.App.Application.Context;


	public Notification ReturnNotification(string title, string content)
	{
		var intent = new Intent(Context, typeof(MainActivity));
		intent.AddFlags(ActivityFlags.NewTask);

		var pendingIntent = PendingIntent.GetActivity(Context, 0, intent, PendingIntentFlags.UpdateCurrent);

		var notificationBuilder = new NotificationCompat.Builder(Context, ForegroundChannelId)
				.SetContentTitle(title)
				.SetContentText(content)
				//.SetSmallIcon(ResourceConstant.Drawable.abc_btn_check_material)
				.SetStyle(new NotificationCompat.BigTextStyle())
				.SetOngoing(true)
				.SetContentIntent(pendingIntent)
			;

		if (Build.VERSION.SdkInt < BuildVersionCodes.O) return notificationBuilder.Build();

		var notificationChannel =
			new NotificationChannel(ForegroundChannelId, title, NotificationImportance.High);

		notificationChannel.EnableLights(true);
		notificationChannel.EnableVibration(true);
		notificationChannel.SetShowBadge(true);

		if (Context.GetSystemService(Context.NotificationService) is not NotificationManager notificationManager)
			return notificationBuilder.Build();

		notificationBuilder.SetChannelId(ForegroundChannelId);
		notificationManager.CreateNotificationChannel(notificationChannel);

		return notificationBuilder.Build();
	}
}