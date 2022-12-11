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
using BL.QueryObjects;

namespace BL.Services.UserServ
{
    public class UserService : IUserService
    {

        private readonly IMapper mapper;
        private readonly IUoWUserInfo uow;
        private readonly UserQueryObject queryObject;

        public UserService(IUoWUserInfo uow, IMapper mapper, UserQueryObject userQuery)
        {
            this.mapper = mapper;
            this.uow = uow;
            queryObject = userQuery;
        }

        public async Task<int> UpdateUserDataAsync(PersonalInfoDto input, int userId)
        {
            if (input.BirthDate > DateTime.Now.AddYears(-3))
            {
                return -3;
            }
            User user = uow.UserRepository.GetByID(userId);
            User? userByEmail = queryObject.GetUserByEmail(input.Email);
            User? userByName = queryObject.GetUserByEmail(input.Name);
            if (userByEmail != null && userByEmail.Id != user.Id)
            {
                return -1;
            }
            if (userByName != null && userByName.Id != user.Id)
            {
                return -2;
            }
            uow.UserRepository.Update(mapper.Map(input, user));
            await uow.CommitAsync();
            return userId;
        }

        public PersonalInfoDto ShowUserData(int userId)
        {
            User user = uow.UserRepository.GetByID(userId);
            if (user == null)
            {
                throw new Exception("Invaid id");
            }
            return mapper.Map<User, PersonalInfoDto>(user);
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
            uow.CommitAsync();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
