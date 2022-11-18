using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.AuthService
{
    public interface IAuthService
    {
        public int RegisterUser(RegistrationDto input);
        public object ChangePassword();
        public object LoginUser();
        public object LogoutUser();
    }
}
