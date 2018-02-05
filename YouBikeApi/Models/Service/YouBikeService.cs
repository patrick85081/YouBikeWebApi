using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouBikeApi.Models.Reposiotry;

namespace YouBikeApi.Models.Service
{
    public class YouBikeService : IYouBikeService
    {
        private IMapper Mapper { get; set; }

        private IYouBikeRepository YouBikeRepository { get; set; }

        public YouBikeService(IMapper mapper, IYouBikeRepository repository)
        {
            this.Mapper = mapper;
            this.YouBikeRepository = repository;
        }

        public List<YouBikeStationDto> GetStations()
        {
            var sourceData = this.YouBikeRepository.GetStations();

            if (sourceData.Any().Equals(false))
            {
                return new List<YouBikeStationDto>();
            }

            var stations = this.Mapper.Map<List<YouBikeStationModel>, List<YouBikeStationDto>>
            (
                sourceData
            );
            
            return stations;
        }
    }
}