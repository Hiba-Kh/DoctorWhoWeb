using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorWho.Db.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DoctorWhoCoreDbContext Context;

        protected BaseRepository(DoctorWhoCoreDbContext context)
        {
            Context = context;
        }
    }
}
