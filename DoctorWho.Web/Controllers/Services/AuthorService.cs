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
    public class AuthorService : IAuthorService
    { 
        private readonly IAuthorRepository authorRepository;
        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
        {
            this.authorRepository = authorRepository;
            this.unitOfWork = unitOfWork;
        }

        public void UpdateAuthor(Author author)
        {
            authorRepository.Update(author);
            unitOfWork.CompleteAsync();
        }
        public bool AuthorExists(int id)
        {
            return authorRepository.AuthorExists(id);
        }
    }
}
