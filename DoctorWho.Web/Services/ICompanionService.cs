using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Services
{
    public interface ICompanionService
    {
        bool CompanionExists(int id);
        Task AddCompanionToEpisodeAsync(int episodeId, int companionId);
    }
}
