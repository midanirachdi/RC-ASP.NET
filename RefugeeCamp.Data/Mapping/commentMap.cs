using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class commentMap : EntityTypeConfiguration<comment>
    {
        public commentMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.body)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("comment", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.body).HasColumnName("body");
            this.Property(t => t.datePublish).HasColumnName("datePublish");
            this.Property(t => t.Topic_ID).HasColumnName("Topic_ID");
            this.Property(t => t.User_ID).HasColumnName("User_ID");

            // Relationships
            this.HasOptional(t => t.topic)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.Topic_ID);
            this.HasOptional(t => t.user)
                .WithMany(t => t.comments)
                .HasForeignKey(d => d.User_ID);

        }
    }
}
