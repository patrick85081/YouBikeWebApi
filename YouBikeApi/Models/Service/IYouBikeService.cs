using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouBikeApi.Models.Service
{
    /// <summary>
    /// Interface IYouBikeService
    /// </summary>
    public interface IYouBikeService
    {
        /// <summary>
        /// 取得 YouBike 場站資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationDto&gt;.</returns>
        List<YouBikeStationDto> GetStations();
    }
}