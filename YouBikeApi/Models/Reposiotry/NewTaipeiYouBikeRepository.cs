using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace YouBikeApi.Models.Reposiotry
{
    public class NewTaipeiYouBikeRepository : IYouBikeRepository
    {
        private Uri DataSource => new Uri("http://data.ntpc.gov.tw/od/data/api/54DDDC93-589C-4858-9C95-18B2046CC1FC?$format=json");

        private TimeSpan DefaultTimeout => new TimeSpan(0, 0, 30);

        private DateTime lastRequestTime = DateTime.MinValue;
        private List<YouBikeStationModel> lastRequestData = Enumerable.Empty<YouBikeStationModel>().ToList();

        public List<YouBikeStationModel> GetStations()
        {
            if (lastRequestTime.Add(TimeSpan.FromMinutes(5)) > DateTime.Now)
                return lastRequestData;

            using (HttpClient client = new HttpClient() {Timeout = DefaultTimeout} )
            {
                HttpResponseMessage response = client.GetAsync(DataSource).Result;

                if (response.IsSuccessStatusCode)
                {
                    var stations = response.Content.ReadAsAsync<List<YouBikeStationModel>>().Result;
                    lastRequestTime = DateTime.Now;
                    lastRequestData = stations;
                    return stations;
                }
                else
                    return Enumerable.Empty<YouBikeStationModel>().ToList();
            } 
        }
    }
}