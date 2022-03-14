using System.Threading.Tasks;
using DoctorWho.Db;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoctorWhoCoreDbContext Context;

        public UnitOfWork(DoctorWhoCoreDbContext context)
        {
            Context = context;
        }

        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
