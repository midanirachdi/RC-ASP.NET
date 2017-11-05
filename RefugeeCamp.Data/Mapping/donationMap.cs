using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class donationMap : EntityTypeConfiguration<donation>
    {
        public donationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.currency)
                .HasMaxLength(255);

            this.Property(t => t.state)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("donation", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.currency).HasColumnName("currency");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.validatedAt).HasColumnName("validatedAt");
            this.Property(t => t.camp_ID).HasColumnName("camp_ID");

            // Relationships
            this.HasOptional(t => t.camp)
                .WithMany(t => t.donations)
                .HasForeignKey(d => d.camp_ID);

        }
    }
}
