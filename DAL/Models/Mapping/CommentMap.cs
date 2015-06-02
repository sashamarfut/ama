using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace DAL.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Text)
                .IsRequired();

            this.Property(t => t.AspNetUserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Comments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Text).HasColumnName("Text");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.AspNetUserId).HasColumnName("AspNetUserId");
            this.Property(t => t.VideoId).HasColumnName("VideoId");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.AspNetUserId);
            this.HasRequired(t => t.Video)
                .WithMany(t => t.Comments)
                .HasForeignKey(d => d.VideoId);

        }
    }
}
