using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
    public class MainPageIndexModel
    {
		public int Page { get; set; }

		public int Total { get; set; }

		public IEnumerable<BookBasicInfoDto> Books { get; set; }
    }
}
