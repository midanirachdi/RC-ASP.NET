using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class mediumMap : EntityTypeConfiguration<medium>
    {
        public mediumMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.path)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("media", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.path).HasColumnName("path");
            this.Property(t => t.title).HasColumnName("title");

            // Relationships
            this.HasMany(t => t.news)
                .WithMany(t => t.media)
                .Map(m =>
                    {
                        m.ToTable("media_news", "refugeescamp");
                        m.MapLeftKey("medias_id");
                        m.MapRightKey("news_id");
                    });


        }
    }
}
