using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Domain
{
    public interface IDoctorRepository
    {
        Task AddAsync(Doctor doctor);
        void Update(Doctor doctor);
        void Remove(Doctor doctor);
        Task<IEnumerable<Doctor>> ListAsync();
    }
}
