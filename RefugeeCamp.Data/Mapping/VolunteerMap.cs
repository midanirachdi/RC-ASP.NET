using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefugeeCamp.Domain.Models;

namespace RefugeeCamp.Data.Mapping
{
    class VolunteerMap: EntityTypeConfiguration<Volunteer>
    {

        public VolunteerMap()
        {
            this.HasMany(t => t.evenements1)
                .WithMany(t => t.Volunteers)
                .Map(m =>
                {
                    m.ToTable("volunter_event", "refugeescamp");
                    m.MapLeftKey("volunteer_id");
                    m.MapRightKey("event_id");
                });

        }
    }
}
