using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppMVC.Controllers
{
    public class CommonController : Controller
    {
        protected string GetGroup()
        {
            string result;
            var identity = (ClaimsIdentity?)User.Identity;
            if (identity == null)
            {
                result = "User";
            }
            else
            {
                result = identity.Claims
               .Where(c => c.Type == ClaimTypes.Role)
               .Select(c => c.Value)
               .FirstOrDefault("User");
            }
            return result;
        }
        protected bool CheckPermissions(int userId)
        {
            if (!int.TryParse(User.Identity?.Name, out int signedUserId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return false;
            }
            if (userId == signedUserId)
            {
                return true;
            }
            string group = GetGroup();
            if (group == "Admin" || group == "Employee")
            {
                return true;
            }
            ModelState.AddModelError("UserId", "Invalid permissions!");
            return false;
        }
        protected int GetValidUser(int? userId)
        {
            if (!int.TryParse(User.Identity?.Name, out int signedUserId))
            {
                ModelState.AddModelError("UserId", "Identity error!");
                return -1;
            }
            if (userId == null || userId == signedUserId)
            {
                return signedUserId;
            }
            string group = GetGroup();
            if (group == "Admin" || group == "Employee")
            {
                return userId.Value;
            }
            return signedUserId;
        }
    }
}
