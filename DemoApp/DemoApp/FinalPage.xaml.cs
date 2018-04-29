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
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			var arg = archiveSwitch.IsToggled ? "archive" : String.Empty;

#if WINDOWS_UWP
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Clean");

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