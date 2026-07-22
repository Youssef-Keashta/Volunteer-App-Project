using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer_App___Studying.Models
{
    class Participation
    {
        public int ParticipationID { get; set; }
        public Volunteer volunteer { get; set; }
        public Events eve { get; set; }
        public decimal HoursLogged { get; set; }
        public string RoleAssigned { get; set; }

        public Participation(Volunteer vol, Events eve, decimal hoursLogged, string role)
        {
            this.volunteer = vol;
            this.eve = eve;
            this.HoursLogged = hoursLogged;
            this.RoleAssigned = role;
        }
        public Participation(int id, Volunteer vol, Events eve, decimal hoursLogged, string role)
        {
            this.ParticipationID = id;
            this.volunteer = vol;
            this.eve = eve;
            this.HoursLogged = hoursLogged;
            this.RoleAssigned = role;
        }

        public override string ToString()
        {
            string _par = $"Participation #{ParticipationID}\n";
            string _vol = $"Volunteer #{volunteer.VolunteerID}:\tName: {volunteer.VolunteerFName} {volunteer.VolunteerMName} {volunteer.VolunteerLName}\n";
            string _eve = $"Event #{eve.EventID}:\tEvent Name: {eve.EventName} - Event Date: {eve.EventDate}\n";
            string _info = $"Number of Hours Logged: {HoursLogged}\t\tRole Assigned: {RoleAssigned ?? "N/A"}\n";

            return (_par + _vol + _eve + _info);
        }
    }
}
