using System;

class Program
{
    static void Main()
    {
        DateOnly date = new DateOnly(2024, 11, 15);
        Volunteer vol = new Volunteer(1, "Youssef Ahmed", 18);
        string text = $"Volunteer #{vol.volunteerID}:\nName: {vol.volunteerName}\t\tAge: {vol.volunteerAge}\nJoin Date: {vol.joinDate.ToString()}\t\tTier: {vol.Tier ?? "N/A"}";
        Console.WriteLine(text);
    }
}

class Volunteer
{
    public int volunteerID { get; set; }
    public string volunteerName { get; set; }
    public int volunteerAge { get; set; }
    public DateOnly joinDate { get; set; }
    public string Tier { get; set; }

    public Volunteer(int volunteerID, string volunteerName, int volunteerAge, DateOnly joinDate, string tier = "N/A")
    {
        this.volunteerID = volunteerID;
        this.volunteerName = volunteerName;
        this.volunteerAge = volunteerAge;
        this.joinDate = joinDate;
        Tier = tier;
    }

    public Volunteer(int volunteerID, string volunteerName, int volunteerAge, string tier = "N/A")
    {
        this.volunteerID = volunteerID;
        this.volunteerName = volunteerName;
        this.volunteerAge = volunteerAge;
        this.joinDate = DateOnly.FromDateTime(DateTime.Now);
        Tier = tier;
    }
}

class Events
{
    public int EventID { get; set; }
    public string EventName { get; set; }
    public DateOnly EventDate { get; set; }
    public string EventType { get; set; }
    public Events(int eveID, string eveName, DateOnly eveDate, string eveType)
    {
        this.EventID = eveID;
        this.EventName = eveName;
        this.EventDate = eveDate;
        this.EventType = eveType;
    }
}

class Participation
{
    public Volunteer volunteer;
    public Events eve;
    public decimal HoursLogged;
    public string RoleAssigned;

    public Participation(Volunteer vol, Events eve,  decimal hoursLogged, string role)
    {
        this.volunteer.volunteerID = vol.volunteerID;
        this.eve.EventID = eve.EventID;
        this.HoursLogged = hoursLogged;
        this.RoleAssigned = role;
    }
}