using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Photo { get; set; }
        public int AvailableLikes { get; set; }
        public int AddingCount { get; set; }

        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }

        public virtual IList<Video> Videos { get; set; }
        public virtual IList<Comment> Comments { get; set; }
    }
}
