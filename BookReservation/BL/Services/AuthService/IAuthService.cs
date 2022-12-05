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
        int RegisterUser(RegistrationDto input);

        object ChangePassword();

        object LoginUser();

        object LogoutUser();
    }
}
