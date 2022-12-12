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

        public void AddGenre(GenreDto genreDto)
        {
            uow.GenreRepository.Insert(mapper.Map<Genre>(genreDto));
            uow.CommitAsync();
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
