using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.Mappers
{
    public class VideoViewModelMapper : IMapToNew<IEnumerable<Video>, IEnumerable<VideoViewModelPreview>>
    {
        public IEnumerable<VideoViewModelPreview> Map(IEnumerable<Video> videos)
        {
            return from video in videos
                   select new VideoViewModelPreview()
                   {
                       VideoId = video.Id,
                       Title = video.Title,
                       Url = video.Url,
                       CreatedDate = video.CreatedDate,
                       Likes = video.Likes,
                       Raiting = video.Raiting,
                       Views = video.Views,

                       UserId = video.UserId,
                       UserName = video.User.AspNetUser.UserName,

                       CommentCount = video.Comments.Count
                   };
        }
    }
}
