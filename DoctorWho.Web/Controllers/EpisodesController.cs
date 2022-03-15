using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Resources;
using DoctorWho.Web.Services;
using DoctorWho.Web.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation.Results;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/episodes")]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService episodeService;
        private readonly IMapper mapper;

        public EpisodesController(IEpisodeService episodeService, IMapper mapper)
        {
            this.episodeService = episodeService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Episode>>> GetEpisodes(int episodeId)
        {
            var episodes = await episodeService.GetEpisodesAsync();
            var episodesResources = mapper.Map<IEnumerable<EpisodeResource>>(episodes);

            return Ok(episodesResources);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateEpisode(EpisodeCreationResource episode)
        {
            var episodeValidator = new EpisodeCreationResourceValidator();
            ValidationResult result = episodeValidator.Validate(episode);

            if (!result.IsValid)
            {
                return BadRequest(result.ToString());
            }

            var episodeToCreate = mapper.Map<Episode>(episode);
            int id = await episodeService.CreateEpisodeAsync(episodeToCreate);
            if (id == -1)
            {
                return BadRequest();
            }
            return Ok($"Episode Id: {id}");
        }

    }
}
