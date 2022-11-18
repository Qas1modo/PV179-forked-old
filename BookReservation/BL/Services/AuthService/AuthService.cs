using AutoMapper;
using BL.DTOs;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.AuthService
{
    public class AuthService: IAuthService
    {
        private readonly IUoWUserInfo uoWUserInfo;
        private readonly IMapper mapper;

        public AuthService(IUoWUserInfo userInfo, IMapper mapper)
        {
            this.uoWUserInfo = userInfo;
            this.mapper = mapper;
        }

        // will be updated after implemented autnhetification (Type change, middleware implementation)
        public int RegisterUser(RegistrationDto input)
        {
            User user = mapper.Map<User>(input);
            user.Salt = Encoding.UTF8.GetString(RandomNumberGenerator.GetBytes(32));
            user.Group = DAL.Enums.Group.User;
            var hashService = SHA256.Create();
            byte[] combinedPassword = Encoding.UTF8.GetBytes(input.OpenPassword + user.Salt);
            user.Password = Convert.ToBase64String(hashService.ComputeHash(combinedPassword));
            return uoWUserInfo.UserRepository.Insert(user);
        }

        public object ChangePassword()
        {
            throw new NotImplementedException();
        }

        public object LoginUser()
        {
            throw new NotImplementedException();
        }

        public object LogoutUser()
        {
            throw new NotImplementedException();
        }
    }
}
