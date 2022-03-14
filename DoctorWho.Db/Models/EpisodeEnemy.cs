using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Models
{
    public class EpisodeEnemy
    {
        public int EpisodeId { get; set; }
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        public Episode Episode { get; set; }
    }
}
