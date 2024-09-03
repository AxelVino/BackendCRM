using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Interactions
    {
        public int InteractionID { get; set; }
        public required Projects Projects { get; set; }
        public required int ProjectID { get; set; }
        public required InteractionTypes InteractionTypes { get; set; }
        public required int Id { get; set; }
        public required DateTime Date { get; set; }
        public required string Notes { get; set; }

    }
}
