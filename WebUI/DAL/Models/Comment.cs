using System;
namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    

        public Video Video { get; set; }
        public int VideoId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
