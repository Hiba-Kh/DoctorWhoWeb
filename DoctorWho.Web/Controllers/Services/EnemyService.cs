using DoctorWho.Domain;
using DoctorWho.Web.Services;
using Supermarket.API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly IEnemyRepository enemyRepository;
        private readonly IUnitOfWork unitOfWork;

        public EnemyService(IEnemyRepository enemyRepository, IUnitOfWork unitOfWork)
        {
            this.enemyRepository = enemyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddEnemyToEpisodeAsync(int episodeId, int enemyId)
        {
            
            enemyRepository.AddEnemyToEpisode(episodeId, enemyId);
            await unitOfWork.CompleteAsync();
        }

        public bool EnemyEpisodeExists(int episodeId, int enemyId)
        {
            return enemyRepository.EnemyEpisodeExists(episodeId, enemyId);
        }

        public bool EnemyExists(int id)
        {
            return enemyRepository.EnemyExists(id);
        }
    }
}
