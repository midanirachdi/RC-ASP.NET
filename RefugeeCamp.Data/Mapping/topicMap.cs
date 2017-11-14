using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class topicMap : EntityTypeConfiguration<topic>
    {
        public topicMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("topic", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.closed).HasColumnName("closed");
            this.Property(t => t.datePublish).HasColumnName("datePublish");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.User_ID).HasColumnName("User_ID");

            // Relationships
            this.HasMany(t => t.tags)
                .WithMany(t => t.topics)
                .Map(m =>
                    {
                        m.ToTable("topic_ref", "refugeescamp");
                        m.MapLeftKey("Topic_id");
                        m.MapRightKey("Tag_id");
                    });

            this.HasOptional(t => t.user);

        }
    }
}
