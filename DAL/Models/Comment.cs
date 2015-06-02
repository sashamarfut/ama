using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string AspNetUserId { get; set; }
        public int VideoId { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Video Video { get; set; }
    }
}
