// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ReactorTodayContainer
{
	[Register ("PreferencesViewController")]
	partial class PreferencesViewController
	{
		[Outlet]
		UIKit.UISwitch DataCacheSwitch { get; set; }

		[Outlet]
		UIKit.UIButton EmptyCacheButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIScrollView locationsScrollView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DataCacheSwitch != null) {
				DataCacheSwitch.Dispose ();
				DataCacheSwitch = null;
			}

			if (EmptyCacheButton != null) {
				EmptyCacheButton.Dispose ();
				EmptyCacheButton = null;
			}

			if (locationsScrollView != null) {
				locationsScrollView.Dispose ();
				locationsScrollView = null;
			}
		}
	}
}
