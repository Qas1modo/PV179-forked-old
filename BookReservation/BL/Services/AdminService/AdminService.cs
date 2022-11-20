using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using DAL.Enums;
using DAL.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.Services.AdminServ
{
    public class AdminService : IAdminService
    {
        private readonly IMapper mapper;
        private readonly IUoWAdmin uow;

        public AdminService(IUoWAdmin uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public void UpdateBook(int bookId, BookDto updatedBook)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            book = mapper.Map(updatedBook, book);
            uow.BookRepository.Update(book);
            uow.Commit();
        }

        public int AddBook(BookDto newBook)
        {
            int id = uow.BookRepository.Insert(mapper.Map<Book>(newBook));
            uow.Commit();
            return id;
        }

        public void DeleteBook(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            book.Deleted = true;
            uow.BookRepository.Update(book);
            uow.Commit();
        }

        public IEnumerable<UserDto> ShowUsers()
        {
            IEnumerable<User> books = uow.UserRepository.GetAll();
            return mapper.Map<IEnumerable<UserDto>>(books);
        }

        public void UpdateUserPermission(int userId, Group newGroup)
        {
            User user = uow.UserRepository.GetByID(userId);
            user.Group = newGroup;
            uow.UserRepository.Update(user);
            uow.Commit();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
