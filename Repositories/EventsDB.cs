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
    class EventsDB
    {
        private static List<Events> Events = new List<Events>();

        public static void AddEventDB(Events eve)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "Insert Into Events (EventName, EventDate, EventType) Values" +
                "(@EventName, @EventDate, @EventType)";

            SqlParameter EveName = new SqlParameter
            {
                ParameterName = "@EventName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = eve.EventName
            };
            SqlParameter EventDate = new SqlParameter
            {
                ParameterName = "@EventDate ",
                SqlDbType = System.Data.SqlDbType.Date,
                Direction = System.Data.ParameterDirection.Input,
                Value = eve.EventDate
            };
            SqlParameter EveType = new SqlParameter
            {
                ParameterName = "@EventType",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = eve.EventType
            };

            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.Add(EveName);
            command.Parameters.Add(EventDate);
            command.Parameters.Add(EveType);

            command.CommandType = System.Data.CommandType.Text;

            conn.Open();
            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Event {eve.EventName} has been inserted successfully");
            }
            conn.Close();

        }

        public static List<Events> ShowEventsDB()
        {
            Events.Clear();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "SELECT * FROM Events";
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            Events eve;
            while (reader.Read())
            {
                eve = new Events(reader.GetInt32("EventID"), reader.GetString("EventName"),
                    DateOnly.FromDateTime(reader.GetDateTime("EventDate")), reader.GetString("EventType"));

                Events.Add(eve);
            }

            return Events;
        }

        public static Events GetEventDB(int id)
        {
            Events.Clear();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "SELECT * FROM Events Where EventID = @EventID";
            SqlParameter EveID = new SqlParameter
            {
                ParameterName = "@EventID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = id
            };
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add(EveID);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            Events eve;

            if (reader.Read())
            {
                eve = new Events(reader.GetInt32("EventID"), reader.GetString("EventName"),
                    DateOnly.FromDateTime(reader.GetDateTime("EventDate")), reader.GetString("EventType"));
            }

            else
            {
                return null;
            }

            return eve;
        }
    }
}
