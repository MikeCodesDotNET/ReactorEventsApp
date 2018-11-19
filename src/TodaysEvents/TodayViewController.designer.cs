// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace TodaysEvents
{
    [Register ("TodayViewController")]
    partial class TodayViewController
    {
        [Outlet]
        UIKit.UILabel eventDescription { get; set; }


        [Outlet]
        UIKit.UILabel eventTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (eventDescription != null) {
                eventDescription.Dispose ();
                eventDescription = null;
            }

            if (eventTitle != null) {
                eventTitle.Dispose ();
                eventTitle = null;
            }
        }
    }
}