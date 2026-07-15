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
    class VolunteerDB
    {
        private static List<Volunteer> Volunteers = new List<Volunteer>();

        public static void AddVolunteerDB()
        {
            Volunteer volunteer = VolunteerUI.AddVolunteerUI();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "Insert Into Volunteers (FirstName, MiddleName, LastName, Age, JoinDate, Tier) Values" +
                "(@FirstName, @MiddleName, @LastName, @Age, @JoinDate, @Tier)";

            SqlParameter FName = new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = volunteer.VolunteerFName
            };
            SqlParameter MName = new SqlParameter
            {
                ParameterName = "@MiddleName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = volunteer.VolunteerMName
            };
            SqlParameter LName = new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Value = volunteer.VolunteerLName
            };
            SqlParameter Age = new SqlParameter
            {
                ParameterName = "@Age",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = volunteer.VolunteerAge
            };
            SqlParameter JoinDate = new SqlParameter
            {
                ParameterName = "@JoinDate",
                SqlDbType = System.Data.SqlDbType.Date,
                Direction = System.Data.ParameterDirection.Input,
                Value = volunteer.JoinDate
            };

            SqlCommand command = new SqlCommand(sql, conn);

            command.Parameters.Add(FName);
            command.Parameters.Add(MName);
            command.Parameters.Add(LName);
            command.Parameters.Add(Age);
            command.Parameters.Add(JoinDate);
            command.Parameters.AddWithValue("@Tier", (object)volunteer.Tier ?? DBNull.Value);

            command.CommandType = System.Data.CommandType.Text;

            conn.Open();
            if(command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Volunteer {volunteer.VolunteerFName} has been inserted successfully");
            }
            conn.Close();
            
        }

        public static List<Volunteer> ShowVolunteersDB()
        {
            Volunteers.Clear();
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "SELECT * FROM Volunteers";
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            Volunteer volunteer;
            while (reader.Read()) 
            {
                volunteer = new Volunteer(reader.GetInt32("VolunteerID"), reader.GetString("FirstName"),
                    reader.GetString("MiddleName"), reader.GetString("LastName"), reader.GetInt32("Age"),
                    DateOnly.FromDateTime(reader.GetDateTime("JoinDate")), reader.IsDBNull("Tier") ? null : reader.GetString("Tier"));
                
                Volunteers.Add(volunteer);
            }

            return Volunteers;
        }

        public static Volunteer GetVolunteerDB(int id)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            SqlConnection conn = new SqlConnection(config.GetSection("ConnStr").Value);
            string sql = "SELECT * FROM Volunteers Where VolunteerID = @VolunteerID";
            SqlParameter VolunteerID = new SqlParameter
            {
                ParameterName = "@VolunteerID",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Input,
                Value = id
            };
            SqlCommand command = new SqlCommand(sql, conn);
            command.CommandType = System.Data.CommandType.Text;
            command.Parameters.Add(VolunteerID);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            Volunteer volunteer;
            if (reader.Read())
            {
                volunteer = new Volunteer(reader.GetInt32("VolunteerID"), reader.GetString("FirstName"),
                    reader.GetString("MiddleName"), reader.GetString("LastName"), reader.GetInt32("Age"),
                    DateOnly.FromDateTime(reader.GetDateTime("JoinDate")), reader.IsDBNull("Tier") ? null : reader.GetString("Tier"));
            }
            else 
            {
                return null;
            }
            return volunteer;
        }
    }
}

