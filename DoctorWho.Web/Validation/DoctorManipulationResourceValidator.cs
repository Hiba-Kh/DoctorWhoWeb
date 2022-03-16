using DoctorWho.Web.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Validation
{
    public class DoctorManipulationResourceValidator : AbstractValidator<DoctorManipulationResource>
    {
        public DoctorManipulationResourceValidator()
        {
            RuleFor(resource => resource.LastEpisodeDate).Null().When(resource => resource.FirstEpisodeDate == null);
            RuleFor(resource => resource.LastEpisodeDate).GreaterThanOrEqualTo(resource => resource.FirstEpisodeDate).When(resource => resource.FirstEpisodeDate != null);
        }
    }
}
