using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class commandeMap : EntityTypeConfiguration<commande>
    {
        public commandeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.address)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("commande", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.ordered).HasColumnName("ordered");
            this.Property(t => t.qteOfProduct).HasColumnName("qteOfProduct");
            this.Property(t => t.shipped).HasColumnName("shipped");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.totalPrice).HasColumnName("totalPrice");
            this.Property(t => t.Admin).HasColumnName("Admin");
            this.Property(t => t.Product).HasColumnName("Product");
            this.Property(t => t.Provider).HasColumnName("Provider");
            this.Property(t => t.Stock).HasColumnName("Stock");

            // Relationships
            this.HasOptional(t => t.provider1)
                .WithMany(t => t.commandes)
                .HasForeignKey(d => d.Provider);
            this.HasOptional(t => t.stock1)
                .WithMany(t => t.commandes)
                .HasForeignKey(d => d.Stock);
            this.HasOptional(t => t.Admin1);
            /*this.HasOptional(t => t.Admin)
                .HasForeignKey(d => d.Admin1);*/
            this.HasOptional(t => t.product1)
                .WithMany(t => t.commandes)
                .HasForeignKey(d => d.Product);

        }
    }
}
