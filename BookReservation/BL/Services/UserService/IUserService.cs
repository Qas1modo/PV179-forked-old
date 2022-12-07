using BL.DTOs;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Enums;

namespace BL.Services.UserServ
{
    public interface IUserService
    {
        void UpdateUserData(PersonalInfoDto input, int userId);

        PersonalInfoDto ShowUserData(int userId);

        IEnumerable<UserDto> ShowUsers();

        void UpdateUserPermission(int userId, Group newGroup);

        void DeleteUser(int userId);
    }
}
