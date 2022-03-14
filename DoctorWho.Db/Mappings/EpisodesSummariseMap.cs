using Dapper.FluentMap.Mapping;
using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Mappings
{
    public class EpisodesSummariseCompanionsMap : EntityMap<EpisodesSummariseCompanions>
    {
        public EpisodesSummariseCompanionsMap()
        {
            Map(e => e.Count).ToColumn("Companion Count");
        }
    }
    public class EpisodesSummariseEnemiesMap : EntityMap<EpisodesSummariseEnemies>
    {
        public EpisodesSummariseEnemiesMap()
        {
            Map(e => e.Count).ToColumn("Enemies Count");
        }
    }
}
