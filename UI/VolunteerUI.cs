using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.Repositories;

namespace Volunteer_App___Studying.UI
{
    class VolunteerUI
    {
        public static Volunteer AddVolunteerUI()
        {
            Console.Write("First Name: ");
            string VFName = Console.ReadLine();

            Console.Write("Middle Name: ");
            string VMName = Console.ReadLine();

            Console.Write("Last Name: ");
            string VLName = Console.ReadLine();

            Console.Write("Volunteer Age: ");
            string age = Console.ReadLine();

            Console.Write("Join Date (yyyy-MM-dd): ");
            string VJDate = Console.ReadLine();

            Console.Write("Tier: ");
            string VTier = Console.ReadLine();

            int VID;
            int VAge;

            while (true)
            {
                bool ValidFields = true;
                if (!Int32.TryParse(age, out VAge))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Age Value!");
                    Console.Write("Volunteer Age: ");
                    age = Console.ReadLine();
                }
                if (ValidFields)
                {
                    break;
                }
            }

            if (!DateOnly.TryParse(VJDate, out DateOnly VJoinDate))
            {
                VJoinDate = DateOnly.FromDateTime(DateTime.Now);
            }

            if (string.IsNullOrWhiteSpace(VTier))
            {
                VTier = null;
            }

            Volunteer volunteer = new Volunteer(0, VFName, VMName, VLName, VAge, VJoinDate, VTier);
            return volunteer;
        }

        public static void ShowVolunteersUI()
        {
            List<Volunteer> Volunteers = VolunteerDB.ShowVolunteersDB();
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var vol in Volunteers)
            {
                Console.Write(vol.ToString());
            }
        }

        public static void GetVolunteerUI()
        {
            Console.Write("Volunteer ID: ");
            string id = Console.ReadLine();
            int VID;
            while (true)
            {
                bool ValidFields = true;
                if (!Int32.TryParse(id, out VID))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid ID Value!");
                    Console.Write("Volunteer ID: ");
                    id = Console.ReadLine();
                }
                if (ValidFields)
                {
                    break;
                }
            }
            Volunteer volunteer = VolunteerDB.GetVolunteerDB(VID);
            Console.Write(volunteer.ToString());
        }
    }
}
