using DAL.Models;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.QueryObjects
{
    public class AuthorQueryObject
    {
        private readonly IUoWAuthor uow;

        public AuthorQueryObject(IUoWAuthor uoWAuthor)
        {
            uow = uoWAuthor;
        }

        public Author? GetAuthorByName(string authorName)
        {
            return uow.AuthorRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .FirstOrDefault();
        }

        public Author GetExistingAuthor(string authorName)
        {
            return uow.AuthorRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .First();
        }
    }
}
