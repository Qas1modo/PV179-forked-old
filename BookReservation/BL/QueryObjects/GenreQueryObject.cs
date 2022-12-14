using System;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;

namespace BL.QueryObjects
{
    public class GenreQueryObject
    {
        private readonly IUoWGenre uoWGenre;

        public GenreQueryObject(IUoWGenre uoWGenre)
        {
            this.uoWGenre = uoWGenre;
        }

        public Genre? GetGenreByName(string name)
        {
            return uoWGenre.GenreRepository.GetQueryable().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}

