using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ReactorToday.Shared.Models;

namespace ReactorToday.Shared.Services
{
    public class EventsService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Event>> GetTodaysEventsAsync(int comingDaysToInclude = 0, GeoPoint geoPoint = null)
        {
            var json = "";

            var date = DateTime.Today.ToString("d");

            if (comingDaysToInclude == 0)
            {
                json = geoPoint == null
                    ? await client.GetStringAsync(new Uri($"https://reactoreventsapi.azurewebsites.net/api/events?date={date}"))
                    : await client.GetStringAsync(new Uri($"https://reactoreventsapi.azurewebsites.net/api/events?date={date}&long={geoPoint.Longitude}&lat={geoPoint.Latitude}"));
            }
            else
            {
                var toDate = DateTime.Now.AddDays(comingDaysToInclude).ToString("d");
                json = geoPoint == null
                    ? await client.GetStringAsync(new Uri($"https://reactoreventsapi.azurewebsites.net/api/events?date={date}&toDate={toDate}"))
                    : await client.GetStringAsync(new Uri($"https://reactoreventsapi.azurewebsites.net/api/events?date={date}&toDate={toDate}&long={geoPoint.Longitude}&lat={geoPoint.Latitude}"));
            }

            var result = (List<Event>) JsonConvert.DeserializeObject<List<Event>>(json, Settings);
            return result;
        }

        public async Task<List<List<Event>>> EventsGroupeByDate()
        {
            var events = await GetTodaysEventsAsync(7, null);
        
            var grouped = events.GroupBy(x => x.StartDate).Select(grp => grp.ToList()).ToList();
            return grouped;
        }

    
        JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
        };
    }
}
