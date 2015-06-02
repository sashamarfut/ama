using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Mappers
{
    public class VideoViewModelMapper : IMapToNew<List<Video>, List<VideoViewModelPreview>>
    {
        public List<VideoViewModelPreview> Map(List<Video> videos)
        {
            return (from video in videos
                   select new VideoViewModelPreview()
                   {
                       VideoId = video.Id,
                       Title = video.Title,
                       Url = video.Url,
                       CreatedDate = video.CreatedDate,
                       Likes = video.Likes,
                       Raiting = video.Raiting,
                       Views = video.Views,

                       UserId = video.AspNetUserId,
                       UserName = video.AspNetUser.UserName,

                       CommentCount = video.Comments.Count
                   }).ToList();
        }
    }
}
