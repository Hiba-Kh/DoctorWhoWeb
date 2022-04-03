using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorForUpdateResource, Author>();
        }
    }
}
