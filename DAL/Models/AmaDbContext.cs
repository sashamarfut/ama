using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DAL.Models.Mapping;

namespace DAL.Models
{
    public partial class amadbContext : DbContext
    {
        static amadbContext()
        {
            Database.SetInitializer<amadbContext>(null);
        }

        public amadbContext()
            : base("Name=amadbContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new VideoMap());
        }
    }
}
