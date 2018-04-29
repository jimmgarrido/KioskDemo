using System;
using System.Diagnostics;
#if WINDOWS_UWP
using Windows.ApplicationModel;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			var mainPage = new MainPage();
			NavigationPage.SetHasNavigationBar(mainPage, false);
			MainPage = new NavigationPage(mainPage);
		}

		protected override async void OnStart()
		{
#if WINDOWS_UWP
            //await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Setup");

#elif __MACOS__
			var process = new ProcessStartInfo("scripts/setup.sh");
			Process.Start(process);
#endif
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
