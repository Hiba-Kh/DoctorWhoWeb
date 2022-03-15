using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoctorWho.Web.Resources
{
    public class EpisodeCreationResource
    {
         
        public string SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public String Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        [Required]
        public int? AuthorId { get; set; }
        [Required]
        public int? DoctorId { get; set; }
        public String Notes { get; set; }

    }
}
