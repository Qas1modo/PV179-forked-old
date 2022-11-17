using BL.DTOs.BasicDtos;
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
        void UpdateTotalStock(int bookId, int newTotal);

        void AddBook(BookDto newBook);

        void DeleteBook(int bookId); // Should add parameter to not show in listing, need to update DAL with EFQUERY

        IEnumerable<UserDto> ShowUsers();

        IEnumerable<UserDto> DeleteUser(int userId);
    }
}
