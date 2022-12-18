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
        Task UpdateUserDataAsync(PersonalInfoDto input, int userId);

        Task<PersonalInfoDto> ShowUserData(int userId);

        Task<QueryResultDto<UserDto>> ShowUsers(int pageNumber);

		int IdUserWithEmail(string email);

        int IdUserWithUsername(string username);

        Task UpdateUserPermission(int userId, Group newGroup);
    }
}
