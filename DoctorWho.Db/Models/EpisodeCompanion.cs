using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Models
{
    public class EpisodeCompanion
    {
        public int EpisodeId { get; set; }
        public int CompanionId { get; set; }
        public Episode Episode { get; set; }
        public Companion Companion { get; set; }
    }
}
