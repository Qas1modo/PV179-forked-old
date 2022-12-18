using BL.Services.AuthServ;
using DAL.Models;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.QueryObjects
{
    public class UserQueryObject
    {

        private readonly IUoWUserInfo uow;

        public UserQueryObject(IUoWUserInfo uoWUserInfo)
        {
            this.uow = uoWUserInfo;
        }

        public User? GetUserByEmail(string email)
        {
            return uow.UserRepository.GetQueryable()
                .Where(x => x.Email == email)
                .FirstOrDefault();
        }

        public User? GetUserByName(string name)
        {
            return uow.UserRepository.GetQueryable()
                .Where(x => x.Name == name)
                .FirstOrDefault();
        }
    }
}
