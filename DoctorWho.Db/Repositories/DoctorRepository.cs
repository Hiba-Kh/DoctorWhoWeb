using DoctorWho.Db.Models;
using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Doctor doctor)
        {
            using var transaction = Context.Database.BeginTransaction();
            Context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Doctors ON");
            await Context.Doctors.AddAsync(doctor);
            Context.SaveChanges();
            transaction.Commit();
        }

        public void Update(Doctor doctor)
        {
            Context.Doctors.Update(doctor);
        }
        public void Remove(Doctor doctor)
        {
            Context.Doctors.Remove(doctor);
        }
        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await Context.Doctors.ToListAsync();
        }

        public bool DoctorExists(int id)
        {
            return Context.Doctors.Any(d => d.DoctorId == id);
        }

        public async Task<Doctor> FindByIdAsync(int id)
        {
            return await Context.Doctors.FindAsync(id);
        }
    }
}
