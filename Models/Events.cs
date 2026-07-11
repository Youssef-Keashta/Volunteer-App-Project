using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer_App___Studying.Models
{
    class Events
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public string EventType { get; set; }
        public Events(int EveID, string EveName, DateOnly EveDate, string EveType)
        {
            this.EventID = EveID;
            this.EventName = EveName;
            this.EventDate = EveDate;
            this.EventType = EveType;
        }
    }
}
