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
	public partial class GuidePage : ContentPage
	{
        int pageIndex = 0;
        int pageCount = 3;
        Color activeColor = Color.FromHex("#e3008c");
        Color otherColor = Color.FromHex("9b9b9b");
        Button[] progressBtns;

        public GuidePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			markdown.Theme = new MyMarkdownTheme();
            markdown.Markdown = Markdown.GetPageContent(pageIndex);

            progressBtns = new Button[] {
                OneBtn, TwoBtn, ThreeBtn, FourBtn
            };
		}

		private async void NextBtnClicked(object sender, EventArgs e)
		{
            if (++pageIndex >= pageCount)
            {
                pageIndex = 2;
                return;
            }

            markdown.Markdown = Markdown.GetPageContent(pageIndex);
            BackBtn.IsVisible = true;

            UpdateProgressButtons();

            //#if WINDOWS_UWP
            //            var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.Default);
            //            pref.CustomSize = new Windows.Foundation.Size(800, 600);

            //            await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default, pref);
            //#elif __MACOS__
            //			NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Normal;
            //			NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
            //#endif
            //            await Navigation.PushAsync(new FinalPage());
        }

        private void PrevBtnClicked(object sender, EventArgs e)
        {
            if (--pageIndex == 0)
                BackBtn.IsVisible = false;
            else
                BackBtn.IsVisible = true;

            markdown.Markdown = Markdown.GetPageContent(pageIndex);
            UpdateProgressButtons();
        }

        private void UpdateProgressButtons()
        {
            for(int i=0; i<pageCount; i++)
            {
                if (i == pageIndex)
                    progressBtns[i].BackgroundColor = activeColor;
                else
                    progressBtns[i].BackgroundColor = otherColor;
            }
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