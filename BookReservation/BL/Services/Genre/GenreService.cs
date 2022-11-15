using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace BL.Services.Genre
{
    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly BookReservationDbContext context;

        public GenreService(BookReservationDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public void AddGenre(GenreDto genreDto)
        {
            using IUoWGenre uow = new EFUoWGenre(context);
            uow.GenreRepository.Insert(mapper.Map<DAL.Models.Genre>(genreDto));
            uow.Commit();
        }

        public void RemoveGenre(object id)
        {
            using IUoWGenre uow = new EFUoWGenre(context);
            uow.GenreRepository.Delete(id);
            uow.Commit();
        }
    }
}
