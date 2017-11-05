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
            this.Property(t => t.address)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.providerName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("provider", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.providerName).HasColumnName("providerName");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.stock_id).HasColumnName("stock_id");
        }
    }
}
