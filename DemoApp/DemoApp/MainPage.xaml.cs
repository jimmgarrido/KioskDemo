using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Xamarin.Forms;
using Windows.ApplicationModel;

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
            await Navigation.PushAsync(new Page1());
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync();
#endif
        }
    }
}
