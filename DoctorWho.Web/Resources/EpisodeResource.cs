using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Resources
{
    public class EpisodeResource
    {
        public int SeriesNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string EpisodeType { get; set; }
        public String Title { get; set; }
        public DateTime EpisodeDate { get; set; }
        public String Notes { get; set; }
        public int AuthorId { get; set; }
        public int DoctorId { get; set; }
    }
}
