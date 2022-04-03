using DoctorWho.Db.Models;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository : BaseRepository, IEnemyRepository
    {
        public EnemyRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Enemy enemy)
        {
            await Context.Enemies.AddAsync(enemy);
        }
        public void Update(Enemy enemy)
        {
            Context.Enemies.Update(enemy);
        }
        public void Remove(Enemy enemy)
        {
            Context.Enemies.Remove(enemy);
        }
        public async Task<Enemy> FindByIdAsync(int id)
        {
            return await Context.Enemies.FindAsync(id);
        }

        public bool EnemyExists(int id)
        {
            return Context.Enemies.Any(e => e.EnemyId == id);
        }

        public void AddEnemyToEpisode(int episodeId, int enemyId)
        {
            var episodeEnemyJoin = new EpisodeEnemy() { EnemyId = enemyId, EpisodeId = episodeId };
            Context.Add(episodeEnemyJoin);
        }

        public bool EnemyEpisodeExists(int episodeId, int enemyId)
        {
            var q = Context.Episodes.Where(e => e.EpisodeId == episodeId).Where(e => e.EpisodeEnemies.Any(ee => ee.EnemyId == enemyId));
            return q.Any();
        }
    }
}
