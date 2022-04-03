using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Services
{
    public interface IEnemyService
    {
        bool EnemyExists(int episodeId);
        Task AddEnemyToEpisodeAsync(int episodeId, int enemyId);
        bool EnemyEpisodeExists(int episodeId,int enemyId);
    }
}
