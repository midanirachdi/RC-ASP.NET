using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class media_newsMap : EntityTypeConfiguration<media_news>
    {
        public media_newsMap()
        {
            // Primary Key
            this.HasKey(t => new { t.medias_id, t.news_id });

            // Properties
            this.Property(t => t.medias_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.news_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("media_news", "refugeescamp");
            this.Property(t => t.medias_id).HasColumnName("medias_id");
            this.Property(t => t.news_id).HasColumnName("news_id");
        }
    }
}
