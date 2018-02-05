using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using YouBikeApi.Models.Reposiotry;
using YouBikeApi.Models.Service;

namespace YouBikeApi.Controllers
{
    public class YouBikeController : ApiController
    {
        private IYouBikeService YouBikeService { get; set; }

        public YouBikeController(IYouBikeService service)
        {
            this.YouBikeService = service;
        }

        [HttpGet]
        public IEnumerable<YouBikeStationDto> GetStatus()
        {
            return YouBikeService.GetStations();
        }
    }
}