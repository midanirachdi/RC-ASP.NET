using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class medicalfolderMap : EntityTypeConfiguration<medicalfolder>
    {
        public medicalfolderMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.apparences)
                .HasMaxLength(255);

            this.Property(t => t.bloodtype)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.doctorname)
                .HasMaxLength(255);

            this.Property(t => t.mentalstate)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("medicalfolder", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.apparences).HasColumnName("apparences");
            this.Property(t => t.bloodpressure).HasColumnName("bloodpressure");
            this.Property(t => t.bloodtype).HasColumnName("bloodtype");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.doctorname).HasColumnName("doctorname");
            this.Property(t => t.height).HasColumnName("height");
            this.Property(t => t.mentalstate).HasColumnName("mentalstate");
            this.Property(t => t.weight).HasColumnName("weight");
        }
    }
}
