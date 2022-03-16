using DoctorWho.Domain;
using DoctorWho.Web.Services;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers.Services
{
    public class CompanionService : ICompanionService
    {
        private readonly ICompanionRepository companionRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompanionService(ICompanionRepository companionRepository, IUnitOfWork unitOfWork)
        {
            this.companionRepository = companionRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddCompanionToEpisodeAsync(int episodeId, int companionId)
        {
            companionRepository.AddCompanionToEpisode(episodeId, companionId);
            await unitOfWork.CompleteAsync();
        }

        public bool CompanionEpisodeExists(int episodeId, int companionId)
        {
            return companionRepository.CompanionEpisodeExists(episodeId, companionId);
        }

        public bool CompanionExists(int id)
        {
            return companionRepository.CompanionExists(id);
        }
    }
}
