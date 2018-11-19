using System;
using System.Linq;

using NotificationCenter;
using Foundation;
using UIKit;

namespace TodaysEvents
{
    public partial class TodayViewController : UIViewController, INCWidgetProviding
    {
        protected TodayViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.
        }

        [Export("widgetPerformUpdateWithCompletionHandler:")]
        public async void WidgetPerformUpdate(Action<NCUpdateResult> completionHandler)
        {
            // Perform any setup necessary in order to update the view.

            // If an error is encoutered, use NCUpdateResultFailed
            // If there's no update required, use NCUpdateResultNoData
            // If there's an update, use NCUpdateResultNewData
            eventTitle.Text = string.Empty;
            eventDescription.Text = string.Empty;

            try
            {
                var locationManager = new CoreLocation.CLLocationManager();
                var location = locationManager.Location;

                var service = new ReactorToday.Shared.Services.EventsService();
                var events = await service.GetTodaysEventsAsync();

                var firstEvent = events.FirstOrDefault();

                eventTitle.Text = firstEvent.Title;
                eventDescription.Text = firstEvent.EventDescription;

                completionHandler(NCUpdateResult.NewData);
            }
            catch(Exception)
            {
                eventTitle.Text = "I'm sorry I've croaked.";
                completionHandler(NCUpdateResult.Failed);
            }
        }
    }
}
