using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using ReactorToday.Shared.Helpers;

namespace ReactorTodayContainer
{
    public partial class PreferencesViewController : UIViewController
    {
        public PreferencesViewController (IntPtr handle) : base (handle)
        {
        }

        List<UIButton> locationButton = new List<UIButton>();

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            EmptyCacheButton.TouchUpInside += (sender, e) => { MonkeyCache.LiteDB.Barrel.Current.EmptyAll();  };
            EmptyCacheButton.Layer.CornerRadius = 4;
            EmptyCacheButton.Layer.MasksToBounds = true;

            DataCacheSwitch.On = Xamarin.Essentials.Preferences.Get("DataCacheEnabled", true);
            DataCacheSwitch.ValueChanged += (object sender, EventArgs e) => 
            {
                if(DataCacheSwitch.On == true)
                {
                    Xamarin.Essentials.Preferences.Set("DataCacheEnabled", true);
                }
                else
                {
                    Xamarin.Essentials.Preferences.Set("DataCacheEnabled", false);
                }
            };

            CreateLocationButtons();
            SetupLocationScrollBar();
        }

        void CreateLocationButtons()
        {
            locationButton.Add(LocationButtonBuilder(ReactorLocations.London));
            locationButton.Add(LocationButtonBuilder(ReactorLocations.NewYork));
            locationButton.Add(LocationButtonBuilder(ReactorLocations.Redmond));
            locationButton.Add(LocationButtonBuilder(ReactorLocations.SanFransisco));
            locationButton.Add(LocationButtonBuilder(ReactorLocations.Seattle));
            locationButton.Add(LocationButtonBuilder(ReactorLocations.Sydney));
        }

        void SetupLocationScrollBar()
        {
            nfloat h = 95.0f;
            nfloat w = 128.0f;
            nfloat padding = 10.0f;
            nint n = locationButton.Count();

            var i = 0;

            while (i < locationButton.Count)
            {
                locationButton[i].Frame = new CGRect(padding * (i + 1) + (i * w), 0, w, h);
                locationsScrollView.AddSubview(locationButton[i]);
                i++;
            }

            locationsScrollView.ContentSize = new CGSize((w + padding) * n, h);
            locationsScrollView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
            locationsScrollView.ShowsVerticalScrollIndicator = false;
            locationsScrollView.ShowsHorizontalScrollIndicator = false;
            locationsScrollView.AlwaysBounceHorizontal = true;
            locationsScrollView.AlwaysBounceVertical = false;
        }

        UIButton LocationButtonBuilder(ReactorLocations loc)
        {
            var location = loc.ToString();
            var button = new UIButton(UIButtonType.Plain);

            //If the key isn't in the preferences then we default to non-selected and save to preferences
            if (!Xamarin.Essentials.Preferences.ContainsKey($"{location}Selected"))
            {
                button.SetBackgroundImage(UIImage.FromFile($"{location}.png"), UIControlState.Normal);
                Xamarin.Essentials.Preferences.Set($"{location}Selected", false);
            }
            else
            {
                //We have the key already so lets set the image accordingly
                var selected = Xamarin.Essentials.Preferences.Get($"{location}Selected", false);
                if(selected == true)
                {
                    button.SetBackgroundImage(UIImage.FromFile($"{location}Selected.png"), UIControlState.Normal);
                }
                else
                {
                    button.SetBackgroundImage(UIImage.FromFile($"{location}.png"), UIControlState.Normal);
                }
            }


            button.SetTitle(string.Empty, UIControlState.Normal);

            button.TouchUpInside += (object sender, EventArgs e) =>
            {
                Xamarin.Essentials.Preferences.Set($"isDirty", true);

                if (Xamarin.Essentials.Preferences.Get($"{location}Selected", false) == false)
                {
                    button.SetBackgroundImage(UIImage.FromFile($"{location}Selected.png"), UIControlState.Normal);
                    Xamarin.Essentials.Preferences.Set($"{location}Selected", true);
                }
                else
                {
                    button.SetBackgroundImage(UIImage.FromFile($"{location}.png"), UIControlState.Normal);
                    Xamarin.Essentials.Preferences.Set($"{location}Selected", false);
                }
            };

            return button;
        }
    }
}