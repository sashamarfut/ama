namespace DAL.Models
{
    public class User
    {
        public int AspNetUserId { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public double Raiting { get; set; }
        public int AvailableLikes { get; set; }
        public int AddingCount { get; set; }        
    }
}
