using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class needMap : EntityTypeConfiguration<need>
    {
        public needMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("need", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.iddcchef).HasColumnName("iddcchef");

            // Relationships
            this.HasOptional(t => t.CampChef);

        }
    }
}
