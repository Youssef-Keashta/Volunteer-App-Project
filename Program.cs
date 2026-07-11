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
            Console.WriteLine("Choose From the following Menu:\n1. Add Volunteer\n2. Show All Volunteers\n3. Exit");
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