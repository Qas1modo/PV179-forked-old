using System;
using BL.DTOs.BasicDtos;
using DAL.Models;

namespace BL.Services.AuthorServ
{
    public interface IAuthorService
    {
        Task<Author> GetOrAddAuthor(string authorName);
    }
}

