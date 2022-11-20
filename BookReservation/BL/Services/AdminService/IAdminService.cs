using BL.DTOs.BasicDtos;
using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.AdminServ
{
    public interface IAdminService
    {
        void UpdateBook(int bookId, BookDto updatedBook);

        int AddBook(BookDto newBook);

        void DeleteBook(int bookId);

        IEnumerable<UserDto> ShowUsers();

        void UpdateUserPermission(int userId, Group newGroup);

        void DeleteUser(int userId);
    }
}
