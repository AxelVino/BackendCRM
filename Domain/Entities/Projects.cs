using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Projects
    {
        public int ProyectID { get; set; }
        public required string ProjectName { get; set; }
        public required CampaignTypes CampaignType { get; set; }
        public required int Id { get; set; }
        public required Clients Clients { get; set; }
        public required int ClientID { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required DateTime CreateDate { get; set; }
        public required DateTime UpdateDate { get; set; }
        public required IList<Tasks> Tasks { get; set; }
        public required IList<Interactions> Interactions { get; set; }

    }
}
