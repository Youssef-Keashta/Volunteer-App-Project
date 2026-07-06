using System;

class Program
{
    static void Main()
    {
        /*Volunteer vol1 = new Volunteer(1, "Youssef", "Ahmed", "Fathy", 21);
        Volunteer vol2 = new Volunteer(2, "Hana", "Mostafa", "Mohamed", 19);
        DateOnly join3 = new DateOnly(2024, 11, 15);
        Volunteer vol3 = new Volunteer(3, "Neveen", "Ibrahim", "Goda", 26, join3, "Head El Far3");

        List<Volunteer> vols= new List<Volunteer>();
        vols.Add(vol1);
        vols.Add(vol2);
        vols.Add(vol3);

        DateOnly date1 = new DateOnly(2026, 8, 5);
        Events eve1 = new Events(1, "El Masrah", date1, "Farz");
        DateOnly date2 = new DateOnly(2026, 7, 15);
        Events eve2 = new Events(2, "Seraj", date2, "Camp");

        List<Events> eves = new List<Events>();
        eves.Add(eve1);
        eves.Add(eve2);

        Participation par1 = new Participation(vol1, eve1, 6, "Volunteering Head");
        Participation par2 = new Participation(vol2, eve2, 6, "Ashbal Head");
        Participation par3 = new Participation(vol1, eve2, 8, "Volunteer");

        List<Participation> pars = new List<Participation>();

        pars.Add(par1);
        pars.Add(par2);
        pars.Add(par3);

        foreach (var vol in vols)
        {
            Console.WriteLine($"Volunteer #{vol.VolunteerID}:\nName: {vol.VolunteerFName} {vol.VolunteerMName} {vol.VolunteerLName}\t\tAge: {vol.VolunteerAge}\nJoin Date: {vol.JoinDate}\t\tTier: {vol.Tier}");
        }

        Console.WriteLine("-------------------------------------------------------------------------");

        foreach (var eve in eves)
        {
            Console.WriteLine($"Event #{eve.EventID}:\nEvent Name: {eve.EventName}\nEvent Type: {eve.EventType}\nEvent Date: {eve.EventDate}");
        }

        Console.WriteLine("-------------------------------------------------------------------------");

        foreach (var par in pars)
        {
            Console.WriteLine($"Volunteer Name: {par.volunteer.VolunteerFName} {par.volunteer.VolunteerMName} {par.volunteer.VolunteerLName}\tEvent Name: {par.eve.EventName}\tHours Logged: {par.HoursLogged}");
        }*/

        VolunteerManager volunteer = new VolunteerManager();
        string choice = "0";
        while (true)
        {
            Console.WriteLine("Choose From the following Menu:\n1. Add Volunteer\n2. Show All Volunteers\n3. Exit");
            choice = Console.ReadLine();
            if (choice == "1")
            {
                volunteer.AddVolunteer();
            }
            else if (choice == "2")
            {
                VolunteerManager.ShowVolunteers();
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

    class VolunteerManager
    {
        private static List<Volunteer> Volunteers = new List<Volunteer>();

        public void AddVolunteer()
        {
            Console.Write("Volunteer ID: ");
            int VID = Int32.Parse(Console.ReadLine());
            Console.Write("First Name: ");
            string VFName = Console.ReadLine();
            Console.Write("Middle Name: ");
            string VMName = Console.ReadLine();
            Console.Write("Last Name: ");
            string VLName = Console.ReadLine();
            Console.Write("Volunteer Age: ");
            int VAge = Int32.Parse(Console.ReadLine());
            Console.Write("Join Date (yyyy-MM-dd): ");
            string VJDate = Console.ReadLine();
            Console.Write("Tier: ");
            string VTier = Console.ReadLine();

            DateOnly VJoinDate;
            if (DateOnly.TryParse(VJDate, out _))
            {
                VJoinDate = DateOnly.Parse(VJDate);
            }
            else
            {
                VJoinDate = DateOnly.FromDateTime(DateTime.Now);
            }

            if (string.IsNullOrWhiteSpace(VTier))
            {
                VTier = "N/A";
            }

            Volunteer volunteer = new Volunteer(VID, VFName, VMName, VLName, VAge, VJoinDate, VTier);
            Volunteers.Add(volunteer);
        }

        public static void ShowVolunteers()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (var vol in Volunteers)
            {
                Console.WriteLine($"Volunteer #{vol.VolunteerID}:\nName: {vol.VolunteerFName} {vol.VolunteerMName} {vol.VolunteerLName}\t\tAge: {vol.VolunteerAge}\nJoin Date: {vol.JoinDate}\t\tTier: {vol.Tier}");
                Console.WriteLine();
            }
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