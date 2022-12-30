// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WeatherReport.ios
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UILabel DateLabel { get; set; }

		[Outlet]
		UIKit.UILabel FeelsLikeLabel { get; set; }

		[Outlet]
		UIKit.UILabel HumidityLabel { get; set; }

		[Outlet]
		UIKit.UISwitch IsDefaultSwitch { get; set; }

		[Outlet]
		UIKit.UILabel LocationLabel { get; set; }

		[Outlet]
		UIKit.UITextField LocationSearchView { get; set; }

		[Outlet]
		UIKit.UILabel TempLabel { get; set; }

		[Outlet]
		UIKit.UILabel WeatherDesLabel { get; set; }

		[Outlet]
		UIKit.UIImageView WeatherImage { get; set; }

		[Outlet]
		UIKit.UILabel WindLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DateLabel != null) {
				DateLabel.Dispose ();
				DateLabel = null;
			}

			if (HumidityLabel != null) {
				HumidityLabel.Dispose ();
				HumidityLabel = null;
			}

			if (IsDefaultSwitch != null) {
				IsDefaultSwitch.Dispose ();
				IsDefaultSwitch = null;
			}

			if (LocationLabel != null) {
				LocationLabel.Dispose ();
				LocationLabel = null;
			}

			if (LocationSearchView != null) {
				LocationSearchView.Dispose ();
				LocationSearchView = null;
			}

			if (TempLabel != null) {
				TempLabel.Dispose ();
				TempLabel = null;
			}

			if (WeatherDesLabel != null) {
				WeatherDesLabel.Dispose ();
				WeatherDesLabel = null;
			}

			if (WeatherImage != null) {
				WeatherImage.Dispose ();
				WeatherImage = null;
			}

			if (WindLabel != null) {
				WindLabel.Dispose ();
				WindLabel = null;
			}

			if (FeelsLikeLabel != null) {
				FeelsLikeLabel.Dispose ();
				FeelsLikeLabel = null;
			}
		}
	}
}
