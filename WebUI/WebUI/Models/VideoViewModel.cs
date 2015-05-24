using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class VideoViewModel
    {
        public VideoViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

        //Video
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Raiting { get; set; }

        //User
        public int UserId { get; set; }
        public string UserName { get; set; }
        
        //Comments
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}