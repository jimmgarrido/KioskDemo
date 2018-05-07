using System;
#if WINDOWS_UWP
using Windows.UI.ViewManagement;
#elif __MACOS__
using AppKit;
#endif
using Xam.Forms.Markdown;
using Xamarin.Forms;

namespace ConferenceKiosk
{
	public partial class GuidePage : ContentPage
	{
        Color activeColor = Color.FromHex("#e3008c");
        Color otherColor = Color.FromHex("9b9b9b");
        Button[] progressBtns;

        public GuidePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			markdown.Theme = new MyMarkdownTheme();
			markdown.Markdown = Markdown.GetNextPage();

            progressBtns = new Button[] {
                BtnOne, BtnTwo, BtnThree
            };
		}

		async void NextBtnClicked(object sender, EventArgs e)
		{
			if (Markdown.IsLastPage)
			{
				var nav = Navigation.PushAsync(new FinalPage());
#if WINDOWS_UWP
                var pref = ViewModePreferences.CreateDefault(ApplicationViewMode.Default);
                pref.CustomSize = new Windows.Foundation.Size(800, 600);

                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default, pref);
#elif __MACOS__
				NSApplication.SharedApplication.MainWindow.Level = NSWindowLevel.Normal;
				NSApplication.SharedApplication.MainWindow.ToggleFullScreen(NSApplication.SharedApplication.MainWindow);
#endif
				await nav;
			}
			else
			{
				markdown.Markdown = Markdown.GetNextPage();
				BackBtn.IsVisible = true;

				UpdateProgressButtons();
			} 
        }

        void PrevBtnClicked(object sender, EventArgs e)
        {
			if(Markdown.WillBeFirstPage)
				BackBtn.IsVisible = false;
			else
				BackBtn.IsVisible = true;
			
			markdown.Markdown = Markdown.GetPrevPage();
            UpdateProgressButtons();
        }

		void ProgressBtnClicked(object sender, EventArgs e)
		{
			var index = sender.GetType() == typeof(ProgressButton) ?
							  (sender as ProgressButton).Index : (Markdown.PageCount - 1);

			if (index == Markdown.Index)
				return;
			
			if (index == 0)
				BackBtn.IsVisible = false;
			else
				BackBtn.IsVisible = true;

			markdown.Markdown = Markdown.GetPage(index);
			UpdateProgressButtons();
		}

        void UpdateProgressButtons()
        {
			for(int i=0; i<Markdown.PageCount-1; i++)
            {
				if (i == Markdown.Index)
					progressBtns[i].BackgroundColor = activeColor;
				else
					progressBtns[i].BackgroundColor = otherColor;
            }

			if (Markdown.IsLastPage)
			{
				phoneIcon.Source = "phone_active.png";
				NextLabel.Text = "DONE";
			}
			else
			{
				phoneIcon.Source = "phone_progress.png";
				NextLabel.Text = "NEXT";
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

	public class ProgressButton : Button
	{
		public static BindableProperty IndexProperty = 
			BindableProperty.Create("Index", typeof(int), typeof(ProgressButton), -1);

		public static BindableProperty IsActiveProperty =
			BindableProperty.Create("IsActive", typeof(bool), typeof(ProgressButton), false);
		
		public int Index
		{
			get 
			{
				return (int)GetValue(IndexProperty);
			}
			set
			{
				SetValue(IndexProperty, value);
			}
		}
		public bool IsActive { get; set; }
	}
}