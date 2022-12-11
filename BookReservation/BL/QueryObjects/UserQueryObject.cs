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

        private readonly IUoWUserInfo uoWUserInfo;

        public UserQueryObject(IUoWUserInfo unitOfWork)
        {
            this.uoWUserInfo = unitOfWork;
        }

        public User? GetUserByEmail(string email)
        {
            return uoWUserInfo.UserRepository.GetQueryable().Where(x => x.Email == email).FirstOrDefault();
        }

        public User? GetUserByName(string name)
        {
            return uoWUserInfo.UserRepository.GetQueryable().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
