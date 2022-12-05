using BL.DTOs;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.UserServ
{
    public interface IUserService
    {
        void UpdateUserData(PersonalInfoDto input, int userId);

        PersonalInfoDto ShowUserData(int userId);
    }
}
