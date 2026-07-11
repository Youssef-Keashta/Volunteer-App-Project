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
            Console.Write("Event ID: ");
            string id = Console.ReadLine();

            Console.Write("Event Name: ");
            string EName = Console.ReadLine();

            Console.Write("Event Date (yyyy-MM-dd): ");
            string date = Console.ReadLine();

            Console.Write("Event Type: ");
            string EType = Console.ReadLine();

            int EID;
            DateOnly EDate;

            while (true)
            {
                bool ValidFields = true;
                if(!Int32.TryParse(id, out EID))
                {
                    ValidFields = false;
                    Console.WriteLine("Invalid ID Value!");
                    Console.Write("Event ID: ");
                    id = Console.ReadLine();
                }
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

            Events eve = new Events(EID, EName, EDate, EType);
            return eve;
        }

        public static void ShowEventsUI(List<Events> events)
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var eve in events)
            {
                Console.WriteLine($"Event #{eve.EventID}:\nEvent Name: {eve.EventName}\t\tEvent Date: {eve.EventDate}\t\tEvent Type: {eve.EventType}\n");
            }
        }
    }
}
