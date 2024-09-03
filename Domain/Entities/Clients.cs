using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Clients
    {
        public int ClientID {  get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone  { get; set; }
        public required string Company { get; set; }
        public required string Adress { get; set; }
        public required DateTime CreateDate { get; set; }
        public required IList<Projects> Projects { get; set; }
    }
}
