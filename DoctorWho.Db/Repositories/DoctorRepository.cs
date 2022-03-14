using DoctorWho.Db.Models;
using DoctorWho.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            await Context.Doctors.AddAsync(doctor);
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
    }
}
