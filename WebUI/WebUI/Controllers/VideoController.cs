using DAL.Models;
using DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    [RoutePrefix("api/Video")]
    public class VideoController : ApiController
    {
        IVideoRepository videoRepository = null;

        public VideoController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        [Route("Videos")]
        public IEnumerable<Video> GetVideos()
        {
            return null;
        }
    }
}
