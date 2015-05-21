using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
       
        public virtual IList<Comment> Comments { get; set; }
    }
}
