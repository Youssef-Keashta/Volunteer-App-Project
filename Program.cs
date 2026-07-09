using System;

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

    class Volunteer
    {
        public int VolunteerID { get; set; }
        public string VolunteerFName { get; set; }
        public string VolunteerMName { get; set; }
        public string VolunteerLName { get; set; }
        public int VolunteerAge { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Tier { get; set; }

        public Volunteer(int VolunteerID, string VolFName, string VolMName, string VolLName, int VolunteerAge, DateOnly JoinDate, string Tier = "N/A")
        {
            this.VolunteerID = VolunteerID;
            this.VolunteerFName = VolFName;
            this.VolunteerMName = VolMName;
            this.VolunteerLName = VolLName;
            this.VolunteerAge = VolunteerAge;
            this.JoinDate = JoinDate;
            this.Tier = Tier;
        }
    }

    class VolunteerUI
    {
        public static Volunteer AddVolunteerUI()
        {
            Console.Write("Volunteer ID: ");
            string id = Console.ReadLine();
            //Int32.TryParse(Console.ReadLine(), out int VID);
            Console.Write("First Name: ");
            string VFName = Console.ReadLine();
            Console.Write("Middle Name: ");
            string VMName = Console.ReadLine();
            Console.Write("Last Name: ");
            string VLName = Console.ReadLine();
            Console.Write("Volunteer Age: ");
            string age = Console.ReadLine();
            //Int32.TryParse(Console.ReadLine(), out int VAge);
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
    }

    class Events
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateOnly EventDate { get; set; }
        public string EventType { get; set; }
        public Events(int EveID, string EveName, DateOnly EveDate, string EveType)
        {
            this.EventID = EveID;
            this.EventName = EveName;
            this.EventDate = EveDate;
            this.EventType = EveType;
        }
    }

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