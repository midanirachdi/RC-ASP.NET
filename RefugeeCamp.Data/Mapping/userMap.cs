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
            this.Property(t => t.role)
                .IsRequired()
                .HasMaxLength(31);

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
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.birthDay).HasColumnName("birthDay");
            this.Property(t => t.disable).HasColumnName("disable");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.lastResetQuery).HasColumnName("lastResetQuery");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.camp_ID).HasColumnName("camp_ID");

            // Relationships
            this.HasMany(t => t.evenements1)
                .WithMany(t => t.users)
                .Map(m =>
                    {
                        m.ToTable("volunter_event", "refugeescamp");
                        m.MapLeftKey("volunteer_id");
                        m.MapRightKey("event_id");
                    });

            this.HasOptional(t => t.camp);

        }
    }
}
