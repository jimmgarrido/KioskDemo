using System;
using System.Diagnostics;
#if WINDOWS_UWP
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel;
#elif __MACOS__
using AppKit;
using Foundation;
#endif
using Xamarin.Forms;
ConferenceKiosk
namespace DemoApp
{
	public partial class RestartPage : ContentPage
	{
		public RestartPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		private async void ResetClicked(object sender, EventArgs e)
		{
#if WINDOWS_UWP
			await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");
#elif __MACOS__
			var process = new ProcessStartInfo("scripts/cleanup.sh", "reset");
			Process.Start(process).WaitForExit();

			var path = NSBundle.MainBundle.BundlePath;
			var task = new NSTask
			{
				LaunchPath = "/usr/bin/open",
				Arguments = new string[] { path }
			};
			task.Launch();
			Environment.Exit(0);
#endif
		}
    }
}