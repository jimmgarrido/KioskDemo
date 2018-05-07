using System;
using System.Diagnostics;
using Xamarin.Forms;
#if WINDOWS_UWP
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel;
#elif __MACOS__
using AppKit;
using Foundation;
#endif

namespace ConferenceKiosk
{
	public partial class FinalPage : ContentPage
	{
		public FinalPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

		private async void ResetBtnClicked(object sender, EventArgs e)
		{
            var arg = (sender.GetType() == typeof(Frame)) ? "archive" : String.Empty;

#if WINDOWS_UWP
            if (arg == String.Empty)
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Clean");
                //await Navigation.PopToRootAsync();
                await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");
            }
            else
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Archive");
                await Navigation.PushAsync(new RestartPage());
                var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
                pref.CustomSize = new Windows.Foundation.Size(400, 600);

                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, pref);
            }

#elif __MACOS__
			if (arg == String.Empty)
			{
				var process = new ProcessStartInfo("scripts/cleanup.sh", arg);
				Process.Start(process).WaitForExit();

				var path = NSBundle.MainBundle.BundlePath;
				var task = new NSTask
				{
					LaunchPath = "/usr/bin/open",
					Arguments = new string[] { path }
				};
				task.Launch();
				Environment.Exit(0);
			}
			else
			{
				var process = new ProcessStartInfo("scripts/cleanup.sh", arg);
				Process.Start(process);

				NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
				NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Floating;
				await Navigation.PushAsync(new RestartPage());
			}

#endif
        }

		async void BackBtnClicked(object sender, System.EventArgs e)
		{
#if WINDOWS_UWP
			var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
            pref.CustomSize = new Windows.Foundation.Size(400, 600);

            await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, pref);
#elif __MACOS__
			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Floating;

#endif
			await Navigation.PopAsync();
		}
	}
}