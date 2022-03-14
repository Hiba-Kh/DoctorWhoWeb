using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Domain
{
    public interface IEnemyRepository
    {
        Task AddAsync(Enemy enemy);
        void Update(Enemy enemy);
        void Remove(Enemy enemy);
        Task<Enemy> FindByIdAsync(int id);
    }
}
