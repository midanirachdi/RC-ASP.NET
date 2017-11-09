using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class providerMap : EntityTypeConfiguration<provider>
    {
        public providerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.adresse)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.nom)
                .HasMaxLength(255);

            this.Property(t => t.tel)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("provider", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adresse).HasColumnName("adresse");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.nom).HasColumnName("nom");
            this.Property(t => t.tel).HasColumnName("tel");
        }
    }
}
