using System;
using System.Diagnostics;
using Xamarin.Forms;
#if WINDOWS_UWP
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel;
#elif __MACOS__
using AppKit;
#endif

namespace DemoApp
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
			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Floating;

			var process = new ProcessStartInfo("scripts/cleanup.sh", arg);

			Process.Start(process).WaitForExit();
			Environment.Exit(0);
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