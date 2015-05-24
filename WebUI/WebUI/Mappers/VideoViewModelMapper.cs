using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Models;

namespace WebUI.Mappers
{
    public class VideoViewModelMapper : IMapToNew<IEnumerable<Video>, IEnumerable<VideoViewModel>>
    {
        public IEnumerable<VideoViewModel> Map(IEnumerable<Video> videos)
        {
            return from video in videos
                   select new VideoViewModel()
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

                       Comments = (from comment in video.Comments
                                  select new CommentViewModel()
                                  {
                                      CommentId = comment.Id,
                                      CreatedDate = comment.CreatedDate,
                                      Text = comment.Text,
                                      UserId = comment.UserId,
                                      UserName = comment.User.AspNetUser.UserName,
                                      Photo = comment.User.Photo
                                  }).ToList()
                   };
        }
    }
}
