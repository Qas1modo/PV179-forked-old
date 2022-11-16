using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BL.Services.GenreService
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
            uow.GenreRepository.Insert(mapper.Map<DAL.Models.Genre>(genreDto));
            uow.Commit();
        }

        public void RemoveGenre(object id)
        {
            uow.GenreRepository.Delete(id);
            uow.Commit();
        }
    }
}
