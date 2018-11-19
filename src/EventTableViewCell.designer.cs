// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ReactorTodayContainer
{
    [Register ("EventTableViewCell")]
    partial class EventTableViewCell
    {
        [Outlet]
        UIKit.UILabel lblDescription { get; set; }


        [Outlet]
        UIKit.UILabel lblLocation { get; set; }


        [Outlet]
        UIKit.UILabel lblStartTime { get; set; }


        [Outlet]
        UIKit.UILabel lblTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblDescription != null) {
                lblDescription.Dispose ();
                lblDescription = null;
            }

            if (lblLocation != null) {
                lblLocation.Dispose ();
                lblLocation = null;
            }

            if (lblStartTime != null) {
                lblStartTime.Dispose ();
                lblStartTime = null;
            }

            if (lblTitle != null) {
                lblTitle.Dispose ();
                lblTitle = null;
            }
        }
    }
}