using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.Comments = new List<CommentModel>();
            this.Videos = new List<VideoModel>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int AvailableLikes { get; set; }
        public int AddingCount { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<VideoModel> Videos { get; set; }
    }
}