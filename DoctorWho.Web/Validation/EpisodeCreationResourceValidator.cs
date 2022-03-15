using DoctorWho.Web.Resources;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Validation
{
    public class EpisodeCreationResourceValidator : AbstractValidator<EpisodeCreationResource>
    {
        public EpisodeCreationResourceValidator()
        {
            RuleFor(resource => resource.EpisodeNumber).GreaterThan(0);
            RuleFor(resource => resource.SeriesNumber).Length(10);

        }
    }
}
