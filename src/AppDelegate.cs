using Foundation;
using UIKit;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

using MonkeyCache.LiteDB;
using System;
using System.Collections.Generic;
using ReactorToday.Shared.Models;

namespace ReactorTodayContainer
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        //refresh interval in hours. 
        private const double RefreshInterval = 4;

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            Barrel.ApplicationId = "events";
            AppCenter.Start("a93e5f2d-66b6-4319-b68f-9d2284cde343", typeof(Analytics), typeof(Crashes));

            UIApplication.SharedApplication.SetMinimumBackgroundFetchInterval(RefreshInterval * 3600);

            if (Xamarin.Essentials.VersionTracking.IsFirstLaunchEver)
                SetDefaults();

#if DEBUG
            Barrel.Current.EmptyAll();
#endif

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        [Export("application:performFetchWithCompletionHandler:")]
        public async void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            List<Event> Events = new List<Event>();
            try
            {
                var service = new ReactorToday.Shared.Services.EventsService();
                Events = await service.GetTodaysEventsAsync();

                MonkeyCache.LiteDB.Barrel.Current.Add<List<Event>>("events", Events, TimeSpan.FromHours(RefreshInterval));
                completionHandler(UIBackgroundFetchResult.NewData);
            }
            catch (Exception)
            {
                completionHandler(UIBackgroundFetchResult.Failed);
            }
        }
   
        void SetDefaults()
        {
            Xamarin.Essentials.Preferences.Set($"LondonSelected", true);
            Xamarin.Essentials.Preferences.Set($"NewYorkSelected", true);
            Xamarin.Essentials.Preferences.Set($"RedmondSelected", true);
            Xamarin.Essentials.Preferences.Set($"SanFransiscoSelected", true);
            Xamarin.Essentials.Preferences.Set($"SeattleSelected", true);
            Xamarin.Essentials.Preferences.Set($"SydneySelecsed", true);
        }
    }
}

