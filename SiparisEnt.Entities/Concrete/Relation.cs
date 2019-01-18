using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisEnt.Entities.Concrete
{
   public class Relation : EntityBase
    {
//Id, Priority, CustomerType, CustomerName, AuthorizedId, ResponsibleStaff, StartClock, EndClock, StartDate, EndDate, RelationshipType, Location, Subject, Description
        public int Priority { get; set; }
        public int CustomerType { get; set; }
        public int CustomerId { get; set; }
        public int AuthorizedId { get; set; }
        public int ResponsibleStaff { get; set; }
        public DateTime StartClock { get; set; }
        public DateTime EndClock { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RelationshipType { get; set; }
        public string Location { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

    }
}
