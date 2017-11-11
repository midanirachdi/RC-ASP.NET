using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class DistrictChefMap : EntityTypeConfiguration<DistrictChef>
    {
        public DistrictChefMap()
        {

            this.Property(t => t.camp_ID).HasColumnName("camp_ID");

            // Relationships
            this.HasOptional(t => t.camp)
                .WithMany(t => t.DistrictChefs)
                .HasForeignKey(d => d.camp_ID);
        }
    }
}