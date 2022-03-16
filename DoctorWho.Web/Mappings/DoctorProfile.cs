using AutoMapper;
using DoctorWho.Db.Models;
using DoctorWho.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Mappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorResource>();
            CreateMap<DoctorManipulationResource, Doctor>();
        }
    }
}
