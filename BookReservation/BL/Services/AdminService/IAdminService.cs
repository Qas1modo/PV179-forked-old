using BL.DTOs.BasicDtos;
using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Admin
{
    public interface IAdminService
    {
        public void UpdateBook(int bookId, BookDto updatedBook);

        public int AddBook(BookDto newBook);

        public void DeleteBook(int bookId);

        public IEnumerable<UserDto> ShowUsers();

        public void UpdateUserPermission(int userId, Group newGroup);

        public void DeleteUser(int userId);
    }
}
