using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer_App___Studying.Models
{
    class Volunteer
    {
        public int VolunteerID { get; set; }
        public string VolunteerFName { get; set; }
        public string VolunteerMName { get; set; }
        public string VolunteerLName { get; set; }
        public int VolunteerAge { get; set; }
        public DateOnly JoinDate { get; set; }
        public string? Tier { get; set; }

        public Volunteer(int VolunteerID, string VolFName, string VolMName, string VolLName, int VolunteerAge, DateOnly JoinDate, string Tier = "N/A")
        {
            this.VolunteerID = VolunteerID;
            this.VolunteerFName = VolFName;
            this.VolunteerMName = VolMName;
            this.VolunteerLName = VolLName;
            this.VolunteerAge = VolunteerAge;
            this.JoinDate = JoinDate;
            this.Tier = Tier ?? null;
        }

        public override string ToString()
        {
            return $"Volunteer #{this.VolunteerID}:\nName: {this.VolunteerFName} {this.VolunteerMName} {this.VolunteerLName}\t\tAge: {this.VolunteerAge}\nJoin Date: {this.JoinDate}\t\tTier: {this.Tier ?? "N/A"}\n";
        }
    }
}
