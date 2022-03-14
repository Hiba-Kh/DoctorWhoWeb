using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Models
{
    public class Companion
    {
        public Companion()
        {
            CompanionEpisodes = new List<EpisodeCompanion>();
        }
        public int CompanionId { get; set; }
        public String CompanionName { get; set; }
        public String WhoPlayed { get; set; }
        public List<EpisodeCompanion> CompanionEpisodes { get; set; }


    }
}
