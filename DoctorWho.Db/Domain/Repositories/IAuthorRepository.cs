using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Domain
{
    public interface IAuthorRepository
    {
        Task AddAsync(Author author);
        void Update(Author author);
        void Remove(Author author);
    }
}
