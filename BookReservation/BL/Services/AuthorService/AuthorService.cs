using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace BL.Services.AuthorServ
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper mapper;
        private readonly IUoWAuthor uow;

        public AuthorService(IUoWAuthor uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public async Task AddAuthor(AuthorDto authorDto)
        {
            uow.AuthorRepository.Insert(mapper.Map<Author>(authorDto));
            await uow.CommitAsync();
        }

        public void RemoveAuthor(int id)
        {
            uow.AuthorRepository.Delete(id);
            uow.CommitAsync();
        }

        public async Task<Author> GetOrAddAuthor(string authorName)
        {
            Author? newAuthor = uow.AuthorRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .FirstOrDefault();
            if (newAuthor != null)
            {
                return newAuthor;
            }
            uow.AuthorRepository.Insert(new() { Name = authorName });
            await uow.CommitAsync();
            return uow.AuthorRepository.GetQueryable()
            .Where(x => x.Name == authorName)
            .First();
        } 
    }
}
