using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.AuthServ
{
    public interface IAuthService
    {
        Task<int> RegisterUserAsync(RegistrationDto input);
        UserAuthDto? Login(UserLoginDto input);
        Task<bool> ChangePasswordAsync(ChangePasswordDto input);
    }
}
