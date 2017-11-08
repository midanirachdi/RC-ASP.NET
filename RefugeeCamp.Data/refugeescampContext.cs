using System.Data.Entity;
using RefugeeCamp.Data.Mapping;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data
{
    public partial class refugeescampContext : DbContext
    {
        static refugeescampContext()
        {
            Database.SetInitializer<refugeescampContext>(null);
        }

        public refugeescampContext()
            : base("Name=refugeescampContext")
        {
        }

        public DbSet<camp> camps { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<donation> donations { get; set; }
        public DbSet<joboffer> joboffers { get; set; }
        public DbSet<medium> media { get; set; }
        public DbSet<medicalfolder> medicalfolders { get; set; }
        public DbSet<need> needs { get; set; }
        public DbSet<news> news { get; set; }
        public DbSet<refugee> refugees { get; set; }
        public DbSet<stock> stocks { get; set; }
        public DbSet<stocknotification> stocknotifications { get; set; }
        public DbSet<tag> tags { get; set; }
        public DbSet<task> tasks { get; set; }
        public DbSet<topic> topics { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new campMap());
            modelBuilder.Configurations.Add(new commentMap());
            modelBuilder.Configurations.Add(new donationMap());
            modelBuilder.Configurations.Add(new jobofferMap());
            modelBuilder.Configurations.Add(new mediumMap());
            modelBuilder.Configurations.Add(new medicalfolderMap());
            modelBuilder.Configurations.Add(new needMap());
            modelBuilder.Configurations.Add(new newsMap());
            modelBuilder.Configurations.Add(new refugeeMap());
            modelBuilder.Configurations.Add(new stockMap());
            modelBuilder.Configurations.Add(new stocknotificationMap());
            modelBuilder.Configurations.Add(new tagMap());
            modelBuilder.Configurations.Add(new taskMap());
            modelBuilder.Configurations.Add(new topicMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
