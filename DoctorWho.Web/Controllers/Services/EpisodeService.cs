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
        private readonly IDoctorRepository doctorRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IUnitOfWork unitOfWork;
        public EpisodeService(IEpisodeRepository episodeRepository, IDoctorRepository doctorRepository, IUnitOfWork unitOfWork, IAuthorRepository authorRepository)
        {
            this.episodeRepository = episodeRepository;
            this.doctorRepository = doctorRepository;
            this.authorRepository = authorRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> CreateEpisodeAsync(Episode episode)
        {
            if(!doctorRepository.DoctorExists(episode.DoctorId))
            {
                return -1;
            }
            if (!authorRepository.AuthorExists(episode.AuthorId))
            {
                return -1;
            }
            await episodeRepository.AddAsync(episode);
            await unitOfWork.CompleteAsync();
            return episode.EpisodeId;
        }

        public async Task<Episode> GetEpisodeAsync(int id)
        {
            return await episodeRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Episode>> GetEpisodesAsync()
        {
            return await episodeRepository.ListAllAsync();
        }

        public bool EpisodeExists(int episodeId)
        {
            return episodeRepository.EpisodeExists(episodeId);
        }


    }
}
