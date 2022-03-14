using DoctorWho.Db.Models;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionRepository : BaseRepository, ICompanionRepository
    {
        public CompanionRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Companion companion)
        {
            await Context.Companions.AddAsync(companion);
            Context.SaveChanges();
        }
        public void Update(Companion companion)
        {
            Context.Companions.Update(companion);
        }
        public void Remove(Companion companion)
        {
            Context.Companions.Remove(companion);
        }
        public async Task<Companion> FindByIdAsync(int id)
        {
            return await Context.Companions.FindAsync(id);
        }

    }
}
