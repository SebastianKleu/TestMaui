using Android.App;


namespace Test.Maui._7.Services;

/// <summary>
/// A service to build a <see cref="Notification"/> that can be sent to the device
/// </summary>
public interface IServiceNotification
{
	/// <summary>
	/// Builds a <see cref="Notification"/> that can be sent to the device
	/// </summary>
	/// <param name="title"></param>
	/// <param name="content"></param>
	/// <returns></returns>
	Notification ReturnNotification(string title, string content);
}