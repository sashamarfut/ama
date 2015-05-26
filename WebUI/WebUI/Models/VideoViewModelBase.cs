using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public abstract class VideoViewModelBase
    {
        public const string VIDEO_LOCATION_PATH = "/Content/Videos/";

        //Video
        public int VideoId { get; set; }
        public string Title { get; set; }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = VIDEO_LOCATION_PATH + value; }
        }
        
        public int Views { get; set; }
        public int Likes { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Raiting { get; set; }

        //User
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}