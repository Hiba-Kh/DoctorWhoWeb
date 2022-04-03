using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> ListAsync();
        bool DoctorExists(int id);
        Task SaveAsync(Doctor doctor);
        Task<Doctor> GetDoctor(int id);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);

    }
}
