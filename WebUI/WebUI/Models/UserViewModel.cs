using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            this.Comments = new List<CommentViewModel>();
            this.Videos = new List<VideoViewModel>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int AvailableLikes { get; set; }
        public int AddingCount { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public List<VideoViewModel> Videos { get; set; }
    }
}