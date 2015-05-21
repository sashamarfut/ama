using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DAL.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
                
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
