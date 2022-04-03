//using DoctorWho.Domain;
using DoctorWho.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(DoctorWhoCoreDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Author author)
        {
            await Context.Authors.AddAsync(author);
        }
        public void Update(Author author)
        {
            Context.Authors.Update(author);
        }
        public void Remove(Author author)
        {
            Context.Authors.Remove(author);
        }

        public bool AuthorExists(int id)
        {
            return Context.Authors.Any(a => a.AuthorId == id);
        }
    }
}
