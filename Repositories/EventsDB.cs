using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.UI;

namespace Volunteer_App___Studying.Repositories
{
    class EventsDB
    {
        private static List<Events> Events = new List<Events>();

        public static void AddEventDB(Events eve)
        {
            Events.Add(eve);
        }

        public static List<Events> ShowEventsDB()
        {
            return Events;
        }

        public static Events GetEventDB(int id)
        {
            return Events.SingleOrDefault(eve => eve.EventID == id);
        }
    }
}
