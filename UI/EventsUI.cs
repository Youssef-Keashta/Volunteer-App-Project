using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.Repositories;

namespace Volunteer_App___Studying.UI
{
    class EventsUI
    {
        public static Events AddEventUI()
        {
            Console.Write("Event Name: ");
            string EName = Console.ReadLine();

            Console.Write("Event Date (yyyy-MM-dd): ");
            string date = Console.ReadLine();

            Console.Write("Event Type: ");
            string EType = Console.ReadLine();

            DateOnly EDate;

            while (true)
            {
                bool ValidFields = true;
                
                if(!DateOnly.TryParse(date, out EDate))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid Date!");
                    Console.Write("Event Date (yyyy-MM-dd): ");
                    date = Console.ReadLine();
                }
                if (ValidFields)
                {
                    break;
                }
            }

            Events eve = new Events(0, EName, EDate, EType);
            return eve;
        }

        public static void ShowEventsUI(List<Events> events)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var eve in events)
            {
                Console.WriteLine(eve.ToString());
            }
        }

        public static int GetEventUI()
        {
            Console.Write("Event ID: ");
            string id = Console.ReadLine();
            int EID;
            while (true)
            {
                bool ValidFields = true;
                if (!Int32.TryParse(id, out EID))
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
            return EID;
        }

        public static void ShowEventUI(Events eve)
        {
            if (eve == null)
            {
                Console.WriteLine("Event Not Found!");
            }
            else
            {
                Console.WriteLine(eve.ToString());
            }
        }
    }
}
