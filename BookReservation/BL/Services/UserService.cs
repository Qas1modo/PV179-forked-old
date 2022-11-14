using AutoMapper;
using BL.DTOs;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class UserService
    {
        private BookReservationDbContext context;
        private IMapper mapper;

        public UserService(BookReservationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool RegisterUser(RegistrationDto input)
        {
            using (IUoWUserInfo uow = new EFUoWUserInfo(context)) // Jak použít Interface, složitější operace (Joiny)
            {
                uow.UserRepository.Insert(new User { Id = 2, BirthDate = input.BirthDate, Email = input.Email }); // Autentizace
            }
            return false;
        }
    }
}
