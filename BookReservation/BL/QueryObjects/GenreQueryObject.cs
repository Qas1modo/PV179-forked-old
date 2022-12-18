using DAL.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.QueryObjects
{
    public class GenreQueryObject
    {

        private readonly IUoWGenre uow;

        public GenreQueryObject(IUoWGenre uoWGenre)
        {
            uow = uoWGenre;
        }
        public Genre? GetGenreByName(string authorName)
        {
            return uow.GenreRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .FirstOrDefault();
        }

        public Genre GetExistingGenre(string authorName)
        {
            return uow.GenreRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .First();
        }
    }
}
