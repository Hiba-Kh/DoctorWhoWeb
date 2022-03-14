using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using Dapper.FluentMap;
using DoctorWho.Db.Mappings;
using DoctorWho.Db.Models;
using Microsoft.Data.SqlClient;

namespace DoctorWho.Db
{
    public class DapperAccess
    {
        public IDbConnection db;
        public DapperAccess(string connString)
        {
            db = new SqlConnection(connString);
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new EpisodesSummariseCompanionsMap());
                config.AddMap(new EpisodesSummariseEnemiesMap());
            });
        }
        public EpisodesSummarise SpSummariseEpisodes()
        {
            EpisodesSummarise result = new EpisodesSummarise();
            using (var multipleResult = db.QueryMultiple("dbo.spSummariseEpisodes", commandType: CommandType.StoredProcedure))
            {
                result.EpisodesSummariseCompanions = multipleResult.Read<EpisodesSummariseCompanions>().ToList();
                result.EpisodesSummariseEnemies = multipleResult.Read<EpisodesSummariseEnemies>().ToList();
            }
            return result;
        }
        
    }
}
