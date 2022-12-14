using System;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;

namespace BL.QueryObjects
{
    public class AuthorQueryObject
    {
        private readonly IUoWAuthor uoWAuthor;

        public AuthorQueryObject(IUoWAuthor uoWAuthor)
        {
            this.uoWAuthor = uoWAuthor;
        }

        public Author? GetAuthorByName(string name)
        {
            return uoWAuthor.AuthorRepository.GetQueryable().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}

