using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Photo { get; set; }
    }
}