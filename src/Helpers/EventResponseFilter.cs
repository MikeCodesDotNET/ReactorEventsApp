using System;
using System.Collections.Generic;
using ReactorToday.Shared.Helpers;
using ReactorToday.Shared.Models;
using Xamarin.Essentials;
using System.Linq;

namespace ReactorTodayContainer.Helpers
{
    public static class EventResponseFilter
    {

        //This is UGLY but its only a POC so who cares! Whoop whoop, live long and live life! 
        public static List<Event> FilterEvents(this List<Event> events)
        {
            var filteredEvents = new List<Event>();

            if(Preferences.Get($"{ReactorLocations.London.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("London")));
            }

            if (Preferences.Get($"{ReactorLocations.NewYork.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("New York")));
            }

            if (Preferences.Get($"{ReactorLocations.Redmond.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("Redmond")));
            }

            if (Preferences.Get($"{ReactorLocations.SanFransisco.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("San Fransisco")));
            }

            if (Preferences.Get($"{ReactorLocations.Seattle.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("Seattle")));
            }

            if (Preferences.Get($"{ReactorLocations.Sydney.ToString()}Selected", true))
            {
                filteredEvents.AddRange(events.Where(x => x.EventLocation.Contains("Sydney")));
            }

            return filteredEvents;
        }
    }
}
