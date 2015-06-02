using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class VideoMap : EntityTypeConfiguration<Video>
    {
        public VideoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired();

            this.Property(t => t.Url)
                .IsRequired();

            this.Property(t => t.AspNetUserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Videos");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Url).HasColumnName("Url");
            this.Property(t => t.Views).HasColumnName("Views");
            this.Property(t => t.Likes).HasColumnName("Likes");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.Raiting).HasColumnName("Raiting");
            this.Property(t => t.AspNetUserId).HasColumnName("AspNetUserId");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Videos)
                .HasForeignKey(d => d.AspNetUserId);

        }
    }
}
