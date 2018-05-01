using System;
#if WINDOWS_UWP
using Windows.UI.ViewManagement;
#elif __MACOS__
using AppKit;
#endif
using Xam.Forms.Markdown;
using Xamarin.Forms;

namespace DemoApp
{
	public partial class Page1 : ContentPage
	{
		public Page1()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			markdown.Theme = new MyMarkdownTheme();
			markdown.Markdown = "# 5 Minute Start: Exploring Xamarin.Forms 3.0\n\nLet's get a quick taste of building beautiful mobile apps with Xamarin.Forms 3.0. In this quick walkthrough you will:\n\n* Personalize the app\n*Extend the app with cross-platform features\n* Use FlexLayout and CSS to create a fluid layout\n*Deploy to your own device!\n\n> If you're on Windows you can use the new Live Reload (Preview) to see your XAML changes without leaving your debug session. Simply make changes to your XAML and save the file.";
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
#if WINDOWS_UWP
            var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.Default);
            pref.CustomSize = new Windows.Foundation.Size(800, 600);

            await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default, pref);
#elif __MACOS__
			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Normal;
			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
#endif
            await Navigation.PushAsync(new FinalPage());
        }
    }

    public class MyMarkdownTheme : DarkMarkdownTheme
    {
        public MyMarkdownTheme()
        {
            BackgroundColor = Color.Black;
        }
    }
}