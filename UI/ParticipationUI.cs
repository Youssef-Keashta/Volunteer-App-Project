using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.Repositories;

namespace Volunteer_App___Studying.UI
{
    class ParticipationUI
    {
        public static Participation AddParticipationUI()
        {
            Console.Write("Volunteer ID: ");
            string Vid = Console.ReadLine();

            Console.Write("Event ID: ");
            string Eid = Console.ReadLine();

            Console.Write("Hours Logged: ");
            string hL = Console.ReadLine();

            Console.Write("Role Assigned: ");
            string RoleAssigned = Console.ReadLine();

            int VID, EID;
            decimal HoursLogged;

            while (true)
            {
                bool ValidFields = true;
                if (!Int32.TryParse(Vid, out VID))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Volunteer ID!");
                    Console.Write("Volunteer ID: ");
                    Vid = Console.ReadLine();
                }
                
                if (!Int32.TryParse(Eid, out EID))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Event ID!");
                    Console.Write("Event ID: ");
                    Eid = Console.ReadLine();
                }

                if (!decimal.TryParse(hL, out HoursLogged))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Hours Value!");
                    Console.Write("Hours Logged: ");
                    hL = Console.ReadLine();
                }

                if (ValidFields)
                {
                    break;
                }
            }

            Participation participation = new Participation(VolunteerDB.GetVolunteerDB(VID), EventsDB.GetEventDB(EID), HoursLogged, RoleAssigned);
            return participation;
        }

        public static void ShowParticipationUI(List<Participation> participations)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var par in participations)
            {
                Console.WriteLine($"Volunteer #{par.volunteer.VolunteerID}:\t\tName: {par.volunteer.VolunteerFName} {par.volunteer.VolunteerMName} {par.volunteer.VolunteerLName}");
                Console.WriteLine($"Event #{par.eve.EventID}:\tEvent Name: {par.eve.EventName}\tEvent Date: {par.eve.EventDate}");
                Console.WriteLine($"Number of Hours Logged: {par.HoursLogged}\t\tRole Assigned: {par.RoleAssigned}");
            }
        }

        public static void GetVolunteerTotalHoursLogged(List<Participation> participations)
        {
            Console.Write("Volunteer ID: ");
            string Vid = Console.ReadLine();

            int VID;
            while (true)
            {
                bool ValidFields = true;
                if (!Int32.TryParse(Vid, out VID))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Volunteer ID!");
                    Console.Write("Volunteer ID: ");
                    Vid = Console.ReadLine();
                }

                if (ValidFields)
                {
                    break;
                }
            }
            decimal sum = 0;
            foreach (var par in participations)
            {
                if (par.volunteer.VolunteerID == VID)
                {
                    sum += par.HoursLogged;
                }
            }

            Console.WriteLine($"Volunteer #{VolunteerDB.GetVolunteerDB(VID).VolunteerID}:\t\tName: {VolunteerDB.GetVolunteerDB(VID).VolunteerFName} {VolunteerDB.GetVolunteerDB(VID).VolunteerMName} {VolunteerDB.GetVolunteerDB(VID).VolunteerLName}" +
                $"\t\tTotal Hours of Participation: {sum}");

        }
    }
}
