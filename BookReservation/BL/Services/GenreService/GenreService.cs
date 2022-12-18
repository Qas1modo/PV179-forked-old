using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace BL.Services.GenreServ
{
    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly IUoWGenre uow;

        public GenreService(IUoWGenre uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task<Genre> GetOrAddGenre(string genreName)
        {
            Genre? newGenre = uow.GenreRepository.GetQueryable()
            .Where(x => x.Name == genreName)
            .FirstOrDefault();
            if (newGenre != null)
            {
                return newGenre;
            }
            uow.GenreRepository.Insert(new Genre() { Name = genreName });
            await uow.CommitAsync();
            return uow.GenreRepository.GetQueryable()
            .Where(x => x.Name == genreName)
            .First();
        }

        public async Task AddGenre(GenreDto genreDto)
        {
            uow.GenreRepository.Insert(mapper.Map<Genre>(genreDto));
            await uow.CommitAsync();
        }

        public void RemoveGenre(int id)
        {
            uow.GenreRepository.Delete(id);
            uow.CommitAsync();
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenres()
        {
            var result = await uow.GenreRepository.GetAll();

            return mapper.Map<IEnumerable<GenreDto>>(result);
        }
    }
}
