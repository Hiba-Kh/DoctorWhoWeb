using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Domain
{
    public interface IEpisodeRepository
    {
        Task AddAsync(Episode episode);
        void Update(Episode episode);
        void Remove(Episode episode);
        Task<Episode> FindByIdAsync(int id);
    }
}
