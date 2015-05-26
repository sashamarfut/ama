﻿using DAL.Models;
using DAL.Repository.Abstract;
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
    public class VideoController : ApiController
    {
        IVideoRepository videoRepository = null;
        IMapToNew<IEnumerable<Video>, IEnumerable<VideoViewModelPreview>> videoMapper = null;

        public VideoController(IVideoRepository videoRepository,
                               IMapToNew<IEnumerable<Video>, IEnumerable<VideoViewModelPreview>> videoMapper)
        {
            this.videoRepository = videoRepository;
            this.videoMapper = videoMapper;
        }

        public IEnumerable<VideoViewModelPreview> Get()
        {
            IEnumerable<Video> video = videoRepository.GetEntities();
            List<VideoViewModelPreview> videoViewModes = videoMapper.Map(video).ToList();
            return videoViewModes;            
        }
    }
}
