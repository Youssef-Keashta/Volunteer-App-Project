using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;

namespace Volunteer_App___Studying.Repositories
{
    class VolunteerDB
    {
        private static List<Volunteer> Volunteers = new List<Volunteer>();

        public static void AddVolunteerDB(Volunteer volunteer)
        {
            Volunteers.Add(volunteer);
        }

        public static List<Volunteer> ShowVolunteersDB()
        {
            return Volunteers;
        }

        public static Volunteer GetVolunteerDB(int id)
        {
            return Volunteers.SingleOrDefault(vol => vol.VolunteerID == id);
        }
    }
}
