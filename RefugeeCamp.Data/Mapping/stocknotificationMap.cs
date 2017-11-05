using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class stocknotificationMap : EntityTypeConfiguration<stocknotification>
    {
        public stocknotificationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.message)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("stocknotification", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateOfNotification).HasColumnName("dateOfNotification");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.stock_id).HasColumnName("stock_id");

            // Relationships
            this.HasOptional(t => t.stock)
                .WithMany(t => t.stocknotifications)
                .HasForeignKey(d => d.stock_id);

        }
    }
}
