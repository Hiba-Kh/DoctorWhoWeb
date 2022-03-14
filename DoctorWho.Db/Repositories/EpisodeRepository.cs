using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository : BaseRepository, IEpisodeRepository
    {
        public EpisodeRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Episode episode)
        {
            await Context.Episodes.AddAsync(episode);
        }
        public void Update(Episode episode)
        {
            Context.Episodes.Update(episode);
        }
        public void Remove(Episode episode)
        {
            Context.Episodes.Remove(episode);
        }

        public async Task<Episode> FindByIdAsync(int id)
        {
            return await Context.Episodes.FindAsync(id);
        }
    }
}
