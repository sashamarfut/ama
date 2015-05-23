using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.AspNetUserId)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Photo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.AspNetUserId).HasColumnName("AspNetUserId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.AvailableLikes).HasColumnName("AvailableLikes");
            this.Property(t => t.AddingCount).HasColumnName("AddingCount");
            this.Property(t => t.Id).HasColumnName("Id");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.AspNetUserId);

        }
    }
}
