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
using DAL.Enums;

namespace BL.Services.UserServ
{
    public class UserService : IUserService
    {

        private readonly IMapper mapper;
        private readonly IUoWUserInfo uow;

        public UserService(IUoWUserInfo uow, IMapper mapper)
        {
            this.mapper = mapper;
            this.uow = uow;
        }

        public void UpdateUserData(PersonalInfoDto input, int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            if (user == null)
            {
                throw new Exception("Invaid id");
            }
            uow.UserRepository.Update(mapper.Map(input, user));
            uow.Commit();
        }

        public PersonalInfoDto ShowUserData(int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            if (user == null)
            {
                throw new Exception("Invaid id");
            }
            return mapper.Map<PersonalInfoDto>(user);
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
