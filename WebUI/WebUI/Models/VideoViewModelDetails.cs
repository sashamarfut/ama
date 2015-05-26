using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class VideoViewModelDetails : VideoViewModelBase
    {
        public VideoViewModelDetails()
        {
            this.Comments = new List<CommentViewModel>();
        }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}