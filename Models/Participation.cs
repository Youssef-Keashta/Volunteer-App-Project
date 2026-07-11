using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteer_App___Studying.Models
{
    class Participation
    {
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
    }
}
