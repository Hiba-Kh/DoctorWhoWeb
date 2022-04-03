using AutoMapper;
using DoctorWho.Db.Domain.Services;
using DoctorWho.Db.Models;
using DoctorWho.Domain;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IUnitOfWork unitOfWork;


        public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
        {
            this.doctorRepository = doctorRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await doctorRepository.ListAllAsync();
        }

        public bool DoctorExists(int id)
        {
            return doctorRepository.DoctorExists(id);
        }

        public async Task SaveAsync(Doctor doctor)
        {
            await doctorRepository.AddAsync(doctor);
            await unitOfWork.CompleteAsync();
            unitOfWork.Complete();
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
            return await doctorRepository.FindByIdAsync(id);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            doctorRepository.Update(doctor);
            unitOfWork.CompleteAsync();
        }

        public void DeleteDoctor(Doctor doctor)
        {
            doctorRepository.Remove(doctor);
            unitOfWork.CompleteAsync();
        }
    }
}
