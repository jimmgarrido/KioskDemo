using System;
using System.Diagnostics;
#if WINDOWS_UWP
using Windows.ApplicationModel;
#endif
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
#if WINDOWS_UWP
            await FullTrustProcessLauncher.LaunchFullTrustProcessForCurrentAppAsync("Setup");

#elif __MACOS__
			var process = new ProcessStartInfo("scripts/setup.sh");
			Process.Start(process);

			Markdown.Init();
#endif
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}