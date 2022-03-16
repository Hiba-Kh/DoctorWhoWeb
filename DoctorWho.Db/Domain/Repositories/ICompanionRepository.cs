﻿using DoctorWho.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Domain
{
    public interface ICompanionRepository
    {
        Task AddAsync(Companion companion);
        void Update(Companion companion);
        void Remove(Companion companion);
        Task<Companion> FindByIdAsync(int id);
        bool CompanionExists(int id);
        void AddCompanionToEpisode(int episodeId, int companionId);
        bool CompanionEpisodeExists(int episodeId, int companionId);
    }
}
