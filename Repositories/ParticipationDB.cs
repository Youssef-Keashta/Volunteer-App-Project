using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Volunteer_App___Studying.Models;
using Volunteer_App___Studying.UI;

namespace Volunteer_App___Studying.Repositories
{
    class ParticipationDB
    {
        private static List<Participation> Participations = new List<Participation>();

        public static void AddParticipationDB(Participation participation)
        {
            //Make sure participation object got instantiated correctly (Not Null)
            if (participation == null)
            {
                Console.WriteLine("Volunteer or Event not available in database - No participation can be created");
                return;
            }

            //Make Sure Participation is not a duplicate (Same Volunteer, Same Event)
            foreach (var par in ShowParticipationDB())
            {
                if (par.volunteer.VolunteerID == participation.volunteer.VolunteerID &&
                    par.eve.EventID == participation.eve.EventID)
                {
                    Console.WriteLine($"{participation.volunteer.VolunteerFName} has already participated in " +
                        $"\"{participation.eve.EventName}\"");
                    return;
                }
            }

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "Insert Into Participation (VolunteerID, EventID, HoursLogged, RoleAssigned) Values" +
                "(@VolunteerID, @EventID, @HoursLogged, @RoleAssigned)";

            SqlParameter VolID = new SqlParameter
            {
                ParameterName = "@VolunteerID ",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = participation.volunteer.VolunteerID
            };
            SqlParameter EveID = new SqlParameter
            {
                ParameterName = "@EventID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = participation.eve.EventID
            };
            SqlParameter HoursLogged = new SqlParameter
            {
                ParameterName = "@HoursLogged",
                SqlDbType = System.Data.SqlDbType.Decimal,
                Direction = System.Data.ParameterDirection.Input,
                Value = participation.HoursLogged
            };

            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.Add(VolID);
            command.Parameters.Add(EveID);
            command.Parameters.Add(HoursLogged);
            command.Parameters.AddWithValue("@RoleAssigned", (object)participation.RoleAssigned ?? DBNull.Value);

            command.CommandType = System.Data.CommandType.Text;

            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Participation for {participation.volunteer.VolunteerFName} in {participation.eve.EventName} event has been inserted successfully");
            }
            conn.Close();

        }

        public static List<Participation> ShowParticipationDB()
        {
            Participations.Clear();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "SELECT * FROM Participation";
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            Participation participation;
            while (reader.Read())
            {
                participation = new Participation(reader.GetInt32("ParticipationID"),
                    VolunteerDB.GetVolunteerDB(reader.GetInt32("VolunteerID")),
                    EventsDB.GetEventDB(reader.GetInt32("EventID")),
                    reader.GetDecimal("HoursLogged"),
                    reader.IsDBNull("RoleAssigned") ? null : reader.GetString("RoleAssigned"));

                Participations.Add(participation);
            }

            return Participations;
        }
    }
}
