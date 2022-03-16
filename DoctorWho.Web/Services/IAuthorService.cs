using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Services
{
    public interface IAuthorService
    {
        void UpdateAuthor(Author author);
        bool AuthorExists(int id);
    }
}
