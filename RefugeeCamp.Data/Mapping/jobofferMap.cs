using System.Data.Entity.ModelConfiguration;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    public class jobofferMap : EntityTypeConfiguration<joboffer>
    {
        public jobofferMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.companyAdress)
                .HasMaxLength(255);

            this.Property(t => t.companyName)
                .HasMaxLength(255);

            this.Property(t => t.contactEmail)
                .HasMaxLength(255);

            this.Property(t => t.contactName)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.fieldOfWork)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("joboffer", "refugeescamp");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.begindate).HasColumnName("begindate");
            this.Property(t => t.companyAdress).HasColumnName("companyAdress");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.contactEmail).HasColumnName("contactEmail");
            this.Property(t => t.contactName).HasColumnName("contactName");
            this.Property(t => t.contactnumber).HasColumnName("contactnumber");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.enddate).HasColumnName("enddate");
            this.Property(t => t.fieldOfWork).HasColumnName("fieldOfWork");
            this.Property(t => t.salaryEstimate).HasColumnName("salaryEstimate");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.CAMPCHEF_ID).HasColumnName("CAMPCHEF_ID");
            this.Property(t => t.DISTRICTCHEF_ID).HasColumnName("DISTRICTCHEF_ID");

            // Relationships
            this.HasOptional(t => t.DistrictChef)
                .WithMany(t => t.joboffers)
                .HasForeignKey(d => d.DISTRICTCHEF_ID);
            this.HasOptional(t => t.CampChef)
                .WithMany(t => t.joboffers)
                .HasForeignKey(d => d.CAMPCHEF_ID);

        }
    }
}
