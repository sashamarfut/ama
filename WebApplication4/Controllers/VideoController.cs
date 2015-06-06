using DAL.Repository.Abstract;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Mappers;
using WebUI.Models;

namespace WebUI.Controllers
{
    [RoutePrefix("api/Video")]
    [Authorize]
    public class VideoController : ApiController
    {
        IVideoRepository videoRepository = null;
        IMapToNew<List<Video>, List<VideoViewModelPreview>> videoMapper = null;

        public VideoController(IVideoRepository videoRepository,
                               IMapToNew<List<Video>, List<VideoViewModelPreview>> videoMapper)
        {
            this.videoRepository = videoRepository;
            this.videoMapper = videoMapper;
        }
        
        [AllowAnonymous]
        public IEnumerable<VideoViewModelPreview> Get(int? limit, int offset = 0)
        {
            IEnumerable<Video> video = videoRepository.GetEntities();//использовать оконные функции

            if (offset > 0)
            {
                video = video.Skip(offset);
            }
            if (limit.HasValue)
            {
                video = video.Take(limit.Value);
            }

            List<VideoViewModelPreview> videoViewModes = videoMapper.Map(video.ToList()).ToList();
            return videoViewModes;            
        }
           
        [HttpGet]  // USE PUT
        [AllowAnonymous]
        public HttpResponseMessage EditLike(int? videoId, string userId)
        {
            int like = 5;

            return Request.CreateResponse<int>(HttpStatusCode.OK, like);
        }
    }
}
