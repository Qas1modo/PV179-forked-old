using System;
using AutoMapper;
using BL.DTOs.BasicDtos;
using DAL;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using BL.QueryObjects;

namespace BL.Services.AuthorServ
{
    public class AuthorService : IAuthorService
    {
        private readonly IUoWAuthor uow;
        private readonly AuthorQueryObject queryObject;

        public AuthorService(IUoWAuthor uow,
            AuthorQueryObject queryObject)
        {
            this.queryObject = queryObject;
            this.uow = uow;
        }

        public async Task<Author> GetOrAddAuthor(string authorName)
        {
            Author? newAuthor = queryObject.GetAuthorByName(authorName);
            if (newAuthor != null)
            {
                return newAuthor;
            }
            uow.AuthorRepository.Insert(new() { Name = authorName });
            await uow.CommitAsync();
            return queryObject.GetExistingAuthor(authorName);
        } 
    }
}
