using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Services
{
    public interface IEpisodeService
    {
        Task<IEnumerable<Episode>> GetEpisodesAsync();
    }
}
