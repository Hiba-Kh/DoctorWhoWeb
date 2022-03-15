using DoctorWho.Db;
using DoctorWho.Domain;
using DoctorWho.Web.Services;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IEpisodeRepository episodeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EpisodeService(IEpisodeRepository episodeRepository, IUnitOfWork unitOfWork)
        {
            this.episodeRepository = episodeRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Episode>> GetEpisodesAsync()
        {
            return await episodeRepository.ListAllAsync();
        }
    }
}
