using AutoMapper;
using DoctorWho.Db.Domain.Services;
using DoctorWho.Db.Models;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await doctorRepository.ListAsync();
        }
    }
}
