using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
