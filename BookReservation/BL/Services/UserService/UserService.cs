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
using Castle.Core.Logging;

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

        public async Task UpdateUserDataAsync(PersonalInfoDto input, int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            uow.UserRepository.Update(mapper.Map(input, user));
            await uow.CommitAsync();
        }

        public async Task<PersonalInfoDto> ShowUserData(int userId)
        {
            User user = await uow.UserRepository.GetByID(userId);
            if (user == null)
            {
                throw new Exception("Invaid id");
            }
            return mapper.Map<User, PersonalInfoDto>(user);
        }

        public int IdUserWithEmail(string email)
        {
            User? user = queryObject.GetUserByEmail(email);
            return user == null ? -1 : user.Id;
        }

        public int IdUserWithUsername(string username)
        {
            User? user = queryObject.GetUserByName(username);
            return user == null ? -1 : user.Id;
        }

        public async Task<IEnumerable<UserDto>> ShowUsers()
        {
            IEnumerable<User> users = await uow.UserRepository.GetAll();
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task UpdateUserPermission(int userId, Group newGroup)
        {
            User user = await uow.UserRepository.GetByID(userId);
            user.Group = newGroup;
            uow.UserRepository.Update(user);
            await uow.CommitAsync();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
