using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class taskMap : EntityTypeConfiguration<task>
    {
        public taskMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.status)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("task", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.UserId).HasColumnName("UserId");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.tasks)
                .HasForeignKey(d => d.UserId);

        }
    }
}
