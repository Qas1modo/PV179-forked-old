using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
	public class AdminPageUsersModel
	{
		public IEnumerable<UserDto> Users { get; set; }
	}
}
