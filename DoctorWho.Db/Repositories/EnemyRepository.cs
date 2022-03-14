using DoctorWho.Domain;
using System;
using System.Collections.Generic;
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
       
    }
}
