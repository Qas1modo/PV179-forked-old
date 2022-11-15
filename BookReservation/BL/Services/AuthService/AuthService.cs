using AutoMapper;
using BL.DTOs;
using BL.Services.AuthService;
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
        private BookReservationDbContext context;
        private IMapper mapper;

        public AuthService(BookReservationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // will be updated after implemented autnhetification (Type change, middleware implementation)
        public int RegisterUser(RegistrationDto input)
        {
            int result = -1;
            using (IUoWUserInfo uow = new EFUoWUserInfo(context))
            {
                User user = mapper.Map<User>(input);
                user.Salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));
                user.Group = DAL.Enums.Group.User;
                var hashService = SHA256.Create();
                user.Password = Convert.ToBase64String(hashService.ComputeHash(Convert.FromBase64String(input.OpenPassword + user.Salt)));
                result = (int) uow.UserRepository.Insert(user);
            }
            return result;
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
