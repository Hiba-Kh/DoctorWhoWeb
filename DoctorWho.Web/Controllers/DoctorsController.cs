using AutoMapper;
using DoctorWho.Db.Domain.Services;
using DoctorWho.Db.Models;
using DoctorWho.Domain;
using DoctorWho.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly IMapper mapper;

        public DoctorsController(IDoctorService doctorService, IMapper mappe)
        {
            this.doctorService = doctorService;
            this.mapper = mappe;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorResource>> GetDoctors()
        {
            var doctors = doctorService.ListAsync().Result;
            var doctorsResources = mapper.Map<IEnumerable<DoctorResource>>(doctors);
            return Ok(doctorsResources);
        }
        //public async Task<ActionResult<IEnumerable<DoctorResource>>> GetDoctors()
        //{
        //    var doctors = await doctorService.ListAsync();
        //    var doctorsResources = mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
        //    return Ok(doctorsResources);
        //}
    }
}
