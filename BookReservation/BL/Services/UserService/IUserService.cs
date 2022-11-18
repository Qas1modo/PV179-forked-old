using BL.DTOs;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.UserService
{
    public interface IUserService
    {
        public void UpdateUserData(PersonalInfoDto input, int userId);

        public PersonalInfoDto ShowUserData(int userId);
    }
}
