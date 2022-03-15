using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Resources
{
    public class DoctorManipulationResource
    {
        [Required]
        public String DoctorName { get; set; }
        [Required]
        public int? DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? FirstEpisodeDate { get; set; }
        public DateTime? LastEpisodeDate { get; set; }
    }
}
