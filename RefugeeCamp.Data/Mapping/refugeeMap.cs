using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class refugeeMap : EntityTypeConfiguration<refugee>
    {
        public refugeeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.adress)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.englishlanguageLevel)
                .HasMaxLength(255);

            this.Property(t => t.fieldOfWork)
                .HasMaxLength(255);

            this.Property(t => t.firstname)
                .HasMaxLength(255);

            this.Property(t => t.frenchlanguageLevel)
                .HasMaxLength(255);

            this.Property(t => t.highestDegree)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.nationality)
                .HasMaxLength(255);

            this.Property(t => t.sex)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("refugee", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.adress).HasColumnName("adress");
            this.Property(t => t.dateOfBirth).HasColumnName("dateOfBirth");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.englishlanguageLevel).HasColumnName("englishlanguageLevel");
            this.Property(t => t.fieldOfWork).HasColumnName("fieldOfWork");
            this.Property(t => t.firstname).HasColumnName("firstname");
            this.Property(t => t.frenchlanguageLevel).HasColumnName("frenchlanguageLevel");
            this.Property(t => t.highestDegree).HasColumnName("highestDegree");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.nationality).HasColumnName("nationality");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.sex).HasColumnName("sex");
            this.Property(t => t.yearsOfExperience).HasColumnName("yearsOfExperience");
            this.Property(t => t.fiche_ID).HasColumnName("fiche_ID");
            this.Property(t => t.camp_ID).HasColumnName("camp_ID");

            // Relationships
            this.HasOptional(t => t.camp)
                .WithMany(t => t.refugees)
                .HasForeignKey(d => d.camp_ID);
            this.HasOptional(t => t.medicalfolder)
                .WithMany(t => t.refugees)
                .HasForeignKey(d => d.fiche_ID);

        }
    }
}
