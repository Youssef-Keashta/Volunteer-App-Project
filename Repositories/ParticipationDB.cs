using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteer_App___Studying.Models;

namespace Volunteer_App___Studying.Repositories
{
    class ParticipationDB
    {
        private static List<Participation> Participations = new List<Participation>();

        public static void AddParticipationDB(Participation participation)
        {
            Participations.Add(participation);
        }

        public static List<Participation> ShowParticipationDB()
        {
            return Participations;
        }
    }
}
