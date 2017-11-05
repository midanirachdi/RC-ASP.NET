using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class newsMap : EntityTypeConfiguration<news>
    {
        public newsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.author)
                .HasMaxLength(255);

            this.Property(t => t.content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("news", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.author).HasColumnName("author");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.dateOfCreation).HasColumnName("dateOfCreation");
        }
    }
}
