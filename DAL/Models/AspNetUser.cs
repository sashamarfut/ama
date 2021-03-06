using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new List<AspNetUserClaim>();
            this.AspNetUserLogins = new List<AspNetUserLogin>();
            this.Comments = new List<Comment>();
            this.Videos = new List<Video>();
            this.AspNetRoles = new List<AspNetRole>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string Discriminator { get; set; }
        public string Email { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
    }
}
