using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class VideoModel
    {
        public VideoModel()
        {
            this.Comments = new List<CommentModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Raiting { get; set; }
        public List<CommentModel> Comments { get; set; }
        public UserModel User { get; set; }
    }
}