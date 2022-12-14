using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.AuthorServ
{
    public interface IAuthorService
    {
        Task<int> AddAuthor(AuthorDto authorDto);

        void RemoveAuthor(int id);
    }
}

