using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace YouBikeApi.Models.Reposiotry
{
    public class TaipeiYouBikeRepository : IYouBikeRepository
    {
        private Uri DataSource => new Uri("http://data.taipei/youbike");

        private TimeSpan DefaultTimeout => new TimeSpan(0, 0, 30);

        private DateTime lastRequestTime = DateTime.MinValue;
        private List<YouBikeStationModel> lastRequestData = Enumerable.Empty<YouBikeStationModel>().ToList();

        /// <summary>
        /// 取得所有 YouBike 場站資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationModel&gt;.</returns>
        public List<YouBikeStationModel> GetStations()
        {
            if (lastRequestTime.Add(TimeSpan.FromMinutes(1)) > DateTime.Now)
                return lastRequestData;

            var originalData = this.RetriveData();

            if (originalData == null || originalData.RetuenCode != 1)
            {
                return new List<YouBikeStationModel>();
            }

            var stations = originalData.ReturnValue.PropertyValues()
                .Where(item => item.HasValues)
                .Select
                (
                    item => JsonConvert.DeserializeObject<YouBikeStationModel>
                    (
                        item.ToString()
                    )
                )
                .ToList();

            lastRequestTime = DateTime.Now;
            lastRequestData = stations;

            return stations;
        }

        /// <summary>
        /// 取得 YouBike 原始 API 資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationModel&gt;.</returns>
        private YouBikeOriginalModel RetriveData()
        {
            using (HttpClient httpClient = new HttpClient { Timeout = DefaultTimeout })
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = httpClient.GetAsync(DataSource).Result;
                var responseStream = response.Content.ReadAsStreamAsync().Result;

                using (GZipStream decompresStream = new GZipStream(responseStream, CompressionMode.Decompress))
                using (StreamReader reader = new StreamReader(decompresStream))
                {
                    var jsonSerializer = new JsonSerializer();
                    var jsonTextReader = new JsonTextReader(reader);

                    var originalData = jsonSerializer.Deserialize<YouBikeOriginalModel>(jsonTextReader);
                    return originalData;
                }
            }
        }
    }
}