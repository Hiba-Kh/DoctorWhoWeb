using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DoctorWho.Db.Models
{
    public class EpisodesSummarise
    {
        public List<EpisodesSummariseCompanions> EpisodesSummariseCompanions { get; set; }
        public List<EpisodesSummariseEnemies> EpisodesSummariseEnemies { get; set; }
    }
    public class EpisodesSummariseCompanions
    {
        public int Count { get; set; }
        public int CompanionId { get; set; }
    }

    public class EpisodesSummariseEnemies
    {
        public int Count { get; set; }
        public int EnemyId { get; set; }
    }
}
