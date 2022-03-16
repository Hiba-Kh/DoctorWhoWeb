using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Resources
{
    public class AuthorForUpdateResource
    {
        [Required]
        public string AuthorName { get; set; }
    }
}
