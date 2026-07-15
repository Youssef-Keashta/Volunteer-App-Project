Create Database VolunteerApp
GO
USE VolunteerApp
Create Table Volunteers(
	VolunteerID int Identity(1, 1) PRIMARY KEY, 
	FirstName varchar(50) Not Null,
	MiddleName varchar(50) Not Null,
	LastName varchar(50) Not Null,
	Age int check (Age >= 14 AND Age <= 18),
	JoinDate date Default CAST(GETDATE() AS date),
	Tier varchar(50) check (Tier = 'LEADER' OR Tier = 'ASHBAL' OR Tier = 'NEWCOMER')
);
Create Table Events(
	EventID int Identity(1, 1) PRIMARY KEY,
	EventName varchar(100) NOT NULL,
	EventDate date NOT NULL,
	EventType varchar(100) NOT NULL
);
Create Table Participation(
	ParticipationID int Identity(1, 1) PRIMARY KEY,
	VolunteerID int NOT NULL,
	CONSTRAINT fk_Volunteer
    FOREIGN KEY (VolunteerID)
    REFERENCES Volunteers(VolunteerID),
	EventID int NOT NULL,
	CONSTRAINT fk_Event
    FOREIGN KEY (EventID)
    REFERENCES Events(EventID),
	HoursLogged Decimal(24, 2) NOT NULL,
	RoleAssigned varchar(100)
);
GO
CREATE PROCEDURE sp_GetTopVolunteers
AS
Begin
	Select TOP 10 Volunteers.VolunteerID, FirstName, MiddleName, LastName, SUM(HoursLogged) As Total
	FROM Volunteers, Participation
	Where Volunteers.VolunteerID = Participation.VolunteerID
	Group By Volunteers.VolunteerID, FirstName, MiddleName, LastName
	Order By Total Desc
END;
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Youssef', 'Ahmed', 'Fathy', 18);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Mohamed', 'Anwar', 'Sayed', 16);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Sara', 'Mahmoud', 'Seif', 18);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Hager', 'Ayman', 'Zaky', 14);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Ahmed', 'Abd-Elrady', 'Hassan', 13);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age)
Values ('Menna', 'Ismail', 'Medht', 15);
INSERT INTO Volunteers (FirstName, MiddleName, LastName, Age, Tier)
Values ('Nour', 'Ahmed', 'Mossad', 16, 'Ashbal');
INSERT INTO Events(EventName, EventDate, EventType)
Values ('Thursday Event', '2026-07-07', 'Farz');
INSERT INTO Events(EventName, EventDate, EventType)
Values ('El-Masra7', '2026-07-10', 'Qafela');
INSERT INTO Events(EventName, EventDate, EventType)
Values ('Volunteer in Resala', '2026-07-12', 'Orientation');
INSERT INTO Participation (VolunteerID, EventID, HoursLogged, RoleAssigned)
Values (1, 3, 5, 'Moshref');
INSERT INTO Participation (VolunteerID, EventID, HoursLogged, RoleAssigned)
Values (1, 1, 2.5, Null);
INSERT INTO Participation (VolunteerID, EventID, HoursLogged, RoleAssigned)
Values (2, 2, 8,Null);
INSERT INTO Participation (VolunteerID, EventID, HoursLogged, RoleAssigned)
Values (3, 2, 8, 'Head El Far3');
INSERT INTO Participation (VolunteerID, EventID, HoursLogged, RoleAssigned)
Values (4, 3, 7, 'Head El Event');
