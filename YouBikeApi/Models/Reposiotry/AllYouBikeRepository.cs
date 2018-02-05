using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouBikeApi.Models.Reposiotry
{
    public class AllYouBikeRepository : IYouBikeRepository
    {
        private IYouBikeRepository[] Repositorys;

        public AllYouBikeRepository(IYouBikeRepository[] repositorys)
        {
            this.Repositorys = repositorys;
        }

        public List<YouBikeStationModel> GetStations()
        {
            return Repositorys.SelectMany(rep =>
                {
                    try
                    {
                        return rep.GetStations();
                    }
                    catch
                    {
                        return Enumerable.Empty<YouBikeStationModel>().ToList();
                    }
                })
                .ToList();
        }
    }
}