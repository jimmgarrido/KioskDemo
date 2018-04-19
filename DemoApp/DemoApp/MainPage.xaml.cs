using System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Xamarin.Forms;

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
            var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
            pref.CustomSize = new Windows.Foundation.Size(500, 500);
            //var test = await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default, pref);
            //System.Diagnostics.Debug.WriteLine($"Window changed: {test}");

            var size = ((Windows.UI.Xaml.Controls.Frame)Window.Current.Content).Height;

            System.Diagnostics.Debug.WriteLine($"Window size: {size}");

            await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, pref);

            await Navigation.PushAsync(new Page1());

            System.Diagnostics.Process.Start("C:\\Users\\jimmy\\Desktop\\test.bat");
        }
    }
}
