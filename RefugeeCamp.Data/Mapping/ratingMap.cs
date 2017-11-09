using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class ratingMap : EntityTypeConfiguration<rating>
    {
        public ratingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idEvent, t.idVolunteer });

            // Properties
            this.Property(t => t.idEvent)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idVolunteer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("rating", "refugeescamp");
            this.Property(t => t.idEvent).HasColumnName("idEvent");
            this.Property(t => t.idVolunteer).HasColumnName("idVolunteer");
            this.Property(t => t.dateOfRating).HasColumnName("dateOfRating");
            this.Property(t => t.mark).HasColumnName("mark");

            // Relationships
            this.HasRequired(t => t.evenement)
                .WithMany(t => t.ratings)
                .HasForeignKey(d => d.idEvent);
            this.HasRequired(t => t.user)
                .WithMany(t => t.ratings)
                .HasForeignKey(d => d.idVolunteer);

        }
    }
}
