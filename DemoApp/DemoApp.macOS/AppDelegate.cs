using AppKit;
using CoreGraphics;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using DemoApp;

namespace DemoApp.macOS
{
	[Register("AppDelegate")]
	public class AppDelegate : FormsApplicationDelegate
	{
		NSWindow window;
		public AppDelegate()
		{
			var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
			var screen = NSScreen.MainScreen.VisibleFrame;

			var rect = new CGSize
			{
				Width = 350,
				Height = screen.Size.Height - 20
			};

			var pos = new CGPoint
			{
				X = 0,
				Y = 0
			};

			window = new NSWindow(new CGRect(pos, rect), style, NSBackingStore.Buffered, false);
			window.Title = "Build 2018";
			window.TitleVisibility = NSWindowTitleVisibility.Hidden;
		}

		public override NSWindow MainWindow
		{
			get { return window; }
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			MainWindow.ToggleFullScreen(this);

			Forms.Init();
			LoadApplication(new App());

			base.DidFinishLaunching(notification);
		}
	}
}
