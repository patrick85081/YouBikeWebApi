using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouBikeApi.Models.Reposiotry
{
    public interface IYouBikeRepository
    {
        /// <summary>
        /// 取得所有 YouBike 場站資料.
        /// </summary>
        /// <returns>List&lt;YouBikeStationModel&gt;.</returns>
        List<YouBikeStationModel> GetStations();
    }
}