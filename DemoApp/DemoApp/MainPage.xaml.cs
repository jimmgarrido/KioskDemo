using System;
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
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
#if WINDOWS_UWP
            var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
            pref.CustomSize = new Windows.Foundation.Size(500, 500);

            await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, pref);
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();

#elif __MACOS__
			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Floating;
#endif
			await Navigation.PushAsync(new Page1());
		}
    }
}
