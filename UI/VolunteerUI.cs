using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;

namespace Volunteer_App___Studying.UI
{
    class VolunteerUI
    {
        public static Volunteer AddVolunteerUI()
        {
            Console.Write("Volunteer ID: ");
            string id = Console.ReadLine();

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
                if (!Int32.TryParse(id, out VID))
                {
                    Console.WriteLine("Invalid ID Value!");
                    Console.Write("Volunteer ID: ");
                    id = Console.ReadLine();
                }
                else if (!Int32.TryParse(age, out VAge))
                {
                    Console.WriteLine("Invalid Age Value!");
                    Console.Write("Volunteer Age: ");
                    age = Console.ReadLine();
                }
                else break;
            }

            if (!DateOnly.TryParse(VJDate, out DateOnly VJoinDate))
            {
                VJoinDate = DateOnly.FromDateTime(DateTime.Now);
            }

            if (string.IsNullOrWhiteSpace(VTier))
            {
                VTier = "N/A";
            }

            Volunteer volunteer = new Volunteer(VID, VFName, VMName, VLName, VAge, VJoinDate, VTier);
            return volunteer;
        }

        public static void ShowVolunteersUI(List<Volunteer> Volunteers)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var vol in Volunteers)
            {
                Console.WriteLine($"Volunteer #{vol.VolunteerID}:\nName: {vol.VolunteerFName} {vol.VolunteerMName} {vol.VolunteerLName}\t\tAge: {vol.VolunteerAge}\nJoin Date: {vol.JoinDate}\t\tTier: {vol.Tier}");
                Console.WriteLine();
            }

        }
    }
}
