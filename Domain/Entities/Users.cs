using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required IList<Tasks> Tasks { get; set; }
    }
}
