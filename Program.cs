using System;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.UI;
using Volunteer_App___Studying.Repositories;

class Program
{
    static void Main()
    {
        string choice = "0";
        while (true)
        {
            Console.WriteLine("Choose From the following Menu:\n" +
                "1. Add Volunteer\n2. Show All Volunteers\n" +
                "3. Add Event\n4. Show Events\n" +
                "5. Select Volunteer (By ID)\n6. Select Event (By ID)\n" +
                "7. Add Participation\n8. Show All Participations\n" +
                "9. Show Total Hours Logged for a Volunteer\n10. Exit");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                VolunteerDB.AddVolunteerDB(VolunteerUI.AddVolunteerUI());

            }
            else if (choice == "2")
            {
                VolunteerUI.ShowVolunteersUI(VolunteerDB.ShowVolunteersDB());
            }
            else if (choice == "3")
            {
                EventsDB.AddEventDB(EventsUI.AddEventUI());
            }
            else if (choice == "4")
            {
                EventsUI.ShowEventsUI(EventsDB.ShowEventsDB());
            }
            else if(choice == "5")
            {
                VolunteerUI.ShowVolunteerUI(VolunteerDB.GetVolunteerDB(VolunteerUI.GetVolunteerUI()));
            }
            else if(choice == "6")
            {
                EventsUI.ShowEventUI(EventsDB.GetEventDB(EventsUI.GetEventUI()));
            }
            else if(choice == "7")
            {
                ParticipationDB.AddParticipationDB(ParticipationUI.AddParticipationUI());
            }
            else if(choice == "8")
            {
                ParticipationUI.ShowParticipationUI(ParticipationDB.ShowParticipationDB());
            }
            else if(choice == "9")
            {
                ParticipationUI.GetVolunteerTotalHoursLogged(ParticipationDB.ShowParticipationDB());
            }

            else if (choice == "10")
            {
                Console.WriteLine("Exiting...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
            }
            Console.WriteLine("-------------------------------------------------------------------------");
        }
    }       
}