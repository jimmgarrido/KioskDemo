using System;
using AppKit;
using ConferenceKiosk.macOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly:ExportRenderer(typeof(Button), typeof(ButtonCustomRenderer))]
namespace ConferenceKiosk.macOS
{
	public class ButtonCustomRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if(Control != null)
			{
				var button = Control as NSButton;
				button.BezelStyle = NSBezelStyle.Circular;
				button.Transparent = true;
			}

		}
	}
}

