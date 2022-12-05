using System;
using BL.DTOs.BasicDtos;

namespace BL.Services.AuthorServ
{
	public interface IAuthorService
	{
        void AddAuthor(AuthorDto authorDto);

        void RemoveAuthor(int id);
    }
}

