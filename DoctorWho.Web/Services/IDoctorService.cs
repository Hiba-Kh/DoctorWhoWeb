using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        bool DoctorExists(int id);
        Task SaveAsync(Doctor doctor);
        Task<Doctor> GetDoctorAsync(int id);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(Doctor doctor);

    }
}
