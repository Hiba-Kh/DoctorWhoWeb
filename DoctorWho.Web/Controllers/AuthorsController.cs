using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Resources;
using DoctorWho.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorWho.Web.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            this.authorService = authorService;
            this.mapper = mapper;
        }

        [HttpPut("{authorId}")]
        public ActionResult UpdateAuthor(int authorId, AuthorForUpdateResource author)
        {
            if (!authorService.AuthorExists(authorId))
            {
                return NotFound("No such Author!");
            }
            var authorToUpdate = mapper.Map<Author>(author);
            authorToUpdate.AuthorId = authorId;
            authorService.UpdateAuthor(authorToUpdate);
            return Ok();
        }
    }
}
