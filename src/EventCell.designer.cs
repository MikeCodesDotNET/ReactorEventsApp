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
	[Register ("EventCell")]
	partial class EventCell
	{
		[Outlet]
		UIKit.UILabel descriptionLabel { get; set; }

		[Outlet]
		UIKit.UILabel endTimeLabel { get; set; }

		[Outlet]
		UIKit.UILabel locationLabel { get; set; }

		[Outlet]
		UIKit.UILabel startTimeLabel { get; set; }

		[Outlet]
		UIKit.UILabel titleLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (titleLabel != null) {
				titleLabel.Dispose ();
				titleLabel = null;
			}

			if (descriptionLabel != null) {
				descriptionLabel.Dispose ();
				descriptionLabel = null;
			}

			if (startTimeLabel != null) {
				startTimeLabel.Dispose ();
				startTimeLabel = null;
			}

			if (endTimeLabel != null) {
				endTimeLabel.Dispose ();
				endTimeLabel = null;
			}

			if (locationLabel != null) {
				locationLabel.Dispose ();
				locationLabel = null;
			}
		}
	}
}
