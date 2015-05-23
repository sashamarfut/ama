using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Video
    {
        public Video()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public decimal Raiting { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual User User { get; set; }
    }
}
