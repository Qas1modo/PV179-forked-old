﻿using BL.DTOs.BasicDtos;
using DAL.Enums;

namespace WebAppMVC.Models
{
	public class AdminPageUsersModel
	{
		public IEnumerable<UserDto> Users { get; set; }
		public int SignedUser { get; set; }
		public int Page { get; set; }
		public int Total { get; set; }
	}
}
