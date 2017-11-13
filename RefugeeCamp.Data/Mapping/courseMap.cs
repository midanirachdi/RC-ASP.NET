using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RefugeeCamp.Domain.Models.Mapping
{
    public class courseMap : EntityTypeConfiguration<course>
    {
        public courseMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("course", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.enddate).HasColumnName("enddate");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.startdate).HasColumnName("startdate");
            this.Property(t => t.iddcchef).HasColumnName("iddcchef");

            // Relationships
           
            this.HasOptional(t => t.DistrictChef)
                .WithMany(t => t.courses)
                .HasForeignKey(d => d.iddcchef);

        }
    }
}
