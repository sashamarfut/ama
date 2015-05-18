using System;
namespace DAL.Models
{
    public class AspNetUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; }
        public string SecurityStamp { get; }
    }
}
