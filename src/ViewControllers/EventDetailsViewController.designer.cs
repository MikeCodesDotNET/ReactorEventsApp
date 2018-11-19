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
	[Register ("EventDetailsViewController")]
	partial class EventDetailsViewController
	{
		[Outlet]
		UIKit.UILabel dayLabel { get; set; }

		[Outlet]
		UIKit.UILabel descriptionLabel { get; set; }

		[Outlet]
		UIKit.UILabel endTimeLabel { get; set; }

		[Outlet]
		UIKit.UIScrollView mainScrollView { get; set; }

		[Outlet]
		UIKit.UIButton registerForEventButton { get; set; }

		[Outlet]
		UIKit.UILabel startTimeLabel { get; set; }

		[Outlet]
		UIKit.UIScrollView technologyScrollView { get; set; }

		[Outlet]
		UIKit.UILabel untilLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mainScrollView != null) {
				mainScrollView.Dispose ();
				mainScrollView = null;
			}

			if (registerForEventButton != null) {
				registerForEventButton.Dispose ();
				registerForEventButton = null;
			}

			if (dayLabel != null) {
				dayLabel.Dispose ();
				dayLabel = null;
			}

			if (descriptionLabel != null) {
				descriptionLabel.Dispose ();
				descriptionLabel = null;
			}

			if (endTimeLabel != null) {
				endTimeLabel.Dispose ();
				endTimeLabel = null;
			}

			if (startTimeLabel != null) {
				startTimeLabel.Dispose ();
				startTimeLabel = null;
			}

			if (technologyScrollView != null) {
				technologyScrollView.Dispose ();
				technologyScrollView = null;
			}

			if (untilLabel != null) {
				untilLabel.Dispose ();
				untilLabel = null;
			}
		}
	}
}
