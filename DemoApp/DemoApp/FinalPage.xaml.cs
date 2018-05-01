using System;
using System.Diagnostics;
using Xamarin.Forms;
#if WINDOWS_UWP
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
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
                await Navigation.PopToRootAsync();
            }
            else
            {
                await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Archive");
                await ApplicationView.GetForCurrentView().TryConsolidateAsync();
            }

#elif __MACOS__
			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Floating;

			var process = new ProcessStartInfo("scripts/cleanup.sh", arg);

			Process.Start(process).WaitForExit();
			Environment.Exit(0);
#endif
        }
	}
}