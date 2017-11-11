using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
      

            this.Property(t => t.adress)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.lastResetQuery)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.birthDay).HasColumnName("birthDay");
            this.Property(t => t.disable).HasColumnName("disable");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.lastResetQuery).HasColumnName("lastResetQuery");
            this.Property(t => t.password).HasColumnName("password");
            this.Map<Admin>(m => m.Requires("role").HasValue("Admin"));
            this.Map<DistrictChef>(m => m.Requires("role").HasValue("DistrictChef"));
            this.Map<CampChef>(m => m.Requires("role").HasValue("CampChef"));
            this.Map<Volunteer>(m => m.Requires("role").HasValue("Volunteer"));
            // Relationships

          



        }
    }
}
