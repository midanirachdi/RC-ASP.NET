using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class campMap : EntityTypeConfiguration<camp>
    {
        public campMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("camp", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.capacity).HasColumnName("capacity");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.campChef_ID).HasColumnName("campChef_ID");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.camps)
                .HasForeignKey(d => d.campChef_ID);

        }
    }
}
