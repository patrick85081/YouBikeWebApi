using Newtonsoft.Json;

namespace YouBikeApi.Models
{
    public class YouBikeStationModel
    {
        /// <summary>
        /// 站點代號
        /// </summary>
        [JsonProperty("sno")]
        public string No { get; set; }

        /// <summary>
        /// 場站名稱(中文)
        /// </summary>
        [JsonProperty("sna")]
        public string Name { get; set; }

        /// <summary>
        /// 場站總停車格
        /// </summary>
        [JsonProperty("tot")]
        public int Total { get; set; }

        /// <summary>
        /// 場站目前車輛數量
        /// </summary>
        [JsonProperty("sbi")]
        public int Bikes { get; set; }

        /// <summary>
        /// 場站區域(中文)
        /// </summary>
        [JsonProperty("sarea")]
        public string Area { get; set; }

        /// <summary>
        /// 資料更新時間
        /// </summary>
        [JsonProperty("mday")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// 緯度
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// 經度
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// 地址(中文)
        /// </summary>
        [JsonProperty("ar")]
        public string Address { get; set; }

        /// <summary>
        /// 場站區域(英文)
        /// </summary>
        [JsonProperty("sareaen")]
        public string AreaEnglish { get; set; }

        /// <summary>
        /// 場站名稱(英文)
        /// </summary>
        [JsonProperty("snaen")]
        public string NameEnglish { get; set; }

        /// <summary>
        /// 地址(英文)
        /// </summary>
        [JsonProperty("aren")]
        public string AddressEnglish { get; set; }

        /// <summary>
        /// 空位數量
        /// </summary>
        [JsonProperty("bemp")]
        public int BikeEmpty { get; set; }

        /// <summary>
        /// 禁用狀態 (0:禁用, 1:正常)
        /// </summary>
        [JsonProperty("act")]
        public string Active { get; set; }
    }
}