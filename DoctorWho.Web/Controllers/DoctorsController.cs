using AutoMapper;
using DoctorWho.Db.Domain.Services;
using DoctorWho.Db.Models;
using DoctorWho.Domain;
using DoctorWho.Web.Resources;
using DoctorWho.Web.Validation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
            var doctors = doctorService.GetDoctorsAsync().Result;
            var doctorsResources = mapper.Map<IEnumerable<DoctorResource>>(doctors);
            return Ok(doctorsResources);
        }

        [HttpGet("{doctorId}", Name = "GetDoctor")]
        public async Task<ActionResult<DoctorResource>> GetDoctor(int doctorId)
        {
            var doctor = await doctorService.GetDoctorAsync(doctorId);
            if (doctor == null)
            {
                return NotFound();
            }
            var doctorResource = mapper.Map<DoctorResource>(doctor);
            return Ok(doctorResource);
        }

        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateOrCreateDoctor(int doctorId, DoctorManipulationResource doctor)
        {
            var doctorToUpdate = await doctorService.GetDoctorAsync(doctorId);
            var doctorValidator = new DoctorManipulationResourceValidator();
            ValidationResult result = doctorValidator.Validate(doctor);
            if(!result.IsValid)
            {
                return BadRequest(result.ToString());
            }
            if (doctorToUpdate == null)  
            { //upsert
                var doctorToAdd = mapper.Map<Doctor>(doctor);
                doctorToAdd.DoctorId = doctorId;
                await doctorService.SaveAsync(doctorToAdd);
                var courseResource = mapper.Map<DoctorResource>(doctorToAdd);
                return CreatedAtRoute("GetDoctor", new { doctorId }, courseResource);
            }
            mapper.Map(doctor, doctorToUpdate);
            doctorService.UpdateDoctor(doctorToUpdate);
            return NoContent();
        }

        [HttpDelete("{doctorId}")]
        public async Task<ActionResult> DeleteDoctor(int doctorId)
        {
            var doctorToDelete = await doctorService.GetDoctorAsync(doctorId);
            if (doctorToDelete == null)
            {
                return NotFound();
            }
            doctorService.DeleteDoctor(doctorToDelete);
            return NoContent();
        }
    }
}
