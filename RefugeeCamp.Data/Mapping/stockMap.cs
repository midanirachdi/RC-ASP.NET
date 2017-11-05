using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class stockMap : EntityTypeConfiguration<stock>
    {
        public stockMap()
        {
            // Primary Key
            this.HasKey(t => t.stock_id);

            // Properties
            this.Property(t => t.notes)
                .HasMaxLength(255);

            this.Property(t => t.stockType)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("stock", "refugeescamp");
            this.Property(t => t.stock_id).HasColumnName("stock_id");
            this.Property(t => t.notes).HasColumnName("notes");
            this.Property(t => t.qteInStock).HasColumnName("qteInStock");
            this.Property(t => t.qteTotal).HasColumnName("qteTotal");
            this.Property(t => t.stockType).HasColumnName("stockType");
            this.Property(t => t.stockValue).HasColumnName("stockValue");
        }
    }
}
