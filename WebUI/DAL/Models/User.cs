using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class User
    {
        public User()
        {
            this.Comments = new List<Comment>();
            this.Videos = new List<Video>();
        }

        public string AspNetUserId { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public int AvailableLikes { get; set; }
        public int AddingCount { get; set; }
        public int Id { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
