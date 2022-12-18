using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using BL.QueryObjects;

namespace BL.Services.GenreServ
{
    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly IUoWGenre uow;
        private readonly GenreQueryObject queryObject;

        public GenreService(IUoWGenre uow,
            IMapper mapper,
            GenreQueryObject queryObject)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.queryObject = queryObject;
        }

        public async Task<Genre> GetOrAddGenre(string genreName)
        {
            Genre? newGenre = queryObject.GetGenreByName(genreName);
            if (newGenre != null)
            {
                return newGenre;
            }
            uow.GenreRepository.Insert(new Genre() { Name = genreName });
            await uow.CommitAsync();
            return queryObject.GetExistingGenre(genreName);
        }

        public async Task AddGenre(GenreDto genreDto)
        {
            uow.GenreRepository.Insert(mapper.Map<Genre>(genreDto));
            await uow.CommitAsync();
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenres()
        {
            var result = await uow.GenreRepository.GetAll();

            return mapper.Map<IEnumerable<GenreDto>>(result);
        }
    }
}
