using System;
using BL.DTOs.BasicDtos;
using DAL.Models;

namespace BL.Services.AuthorServ
{
    public interface IAuthorService
    {
        Task AddAuthor(AuthorDto authorDto);

        Task<Author> GetOrAddAuthor(string authorName);

        void RemoveAuthor(int id);
    }
}

