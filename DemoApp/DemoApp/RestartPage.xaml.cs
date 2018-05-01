using System;
#if WINDOWS_UWP
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel;
#elif __MACOS__
using AppKit;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
	public partial class RestartPage : ContentPage
	{
		public RestartPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
		}

        private async void ResetClicked(object sender, EventArgs e)
        {
            await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");
        }
    }
}