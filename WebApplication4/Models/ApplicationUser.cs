using Microsoft.AspNet.Identity.EntityFramework;
namespace WebService.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
    }
}