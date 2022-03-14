using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Models
{
    public class ViewEpisodes
    {
        public int EpisodeId { get; private set; }
        public String Title { get; private set; }
        public String AuthorName { get; private set; }
        public String DoctorName { get; private set; }
        public String Companions { get; private set; }
        public String Enemies { get; private set; }
    }
}
