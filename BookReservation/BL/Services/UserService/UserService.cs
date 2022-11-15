using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.Services.UserService
{
    public class UserService : IUserService
    {

        private BookReservationDbContext context;
        private IMapper mapper;

        public UserService(BookReservationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void UpdateUserData(PersonalInfoDto input, int userId)
        {
            using IUoWUserInfo uow = new EFUoWUserInfo(context);
            User user = uow.UserRepository.GetByID(userId);
            if (user == null)
            {
                throw new Exception("Invaid id");
            }
            User newUser = mapper.Map(input, user);
            uow.UserRepository.Update(newUser);
            uow.Commit();
        }

        public PersonalInfoDto ShowUserData(int userId)
        {
            using var uow = new EFUoWUserInfo(context);
            User user = uow.UserRepository.GetByID(userId);
            return mapper.Map<PersonalInfoDto>(user);       
        }

        public UserDto GetUser(int userId)
        {
            using var uow = new EFUoWUserInfo(context);
            User user = uow.UserRepository.GetByID(userId);
            return mapper.Map<UserDto>(user);
        }
    }
}
