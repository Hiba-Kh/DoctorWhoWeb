using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Mappings
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeResource>();//.ForMember(
             //   dst => dst.DoctorName,
            //    opt => opt.MapFrom(src => src.Doctor.DoctorName));
                                    
                
        }
    }
}
