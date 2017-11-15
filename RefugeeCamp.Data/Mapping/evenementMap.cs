using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class evenementMap : EntityTypeConfiguration<evenement>
    {
        public evenementMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.imagename)
                .HasMaxLength(255);

            this.Property(t => t.location)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("evenement", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateEvent).HasColumnName("dateEvent");
            this.Property(t => t.imagename).HasColumnName("imagename");
            this.Property(t => t.location).HasColumnName("location");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.nbplace).HasColumnName("nbplace");
            this.Property(t => t.creator_id).HasColumnName("creator_id");

            // Relationships
            this.HasOptional(t => t.Campchef)
                .WithMany(t => t.evenements)
                .HasForeignKey(d => d.creator_id);

            this.HasMany(t => t.refugees)
                .WithMany(t => t.evenements)
                .Map(m =>
                    {
                        m.ToTable("refugee_event", "refugeescamp");
                        m.MapLeftKey("event_id");
                        m.MapRightKey("refugee_id");
                    });



        }
    }
}
