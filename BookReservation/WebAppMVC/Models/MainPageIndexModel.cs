using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
    public class MainPageIndexModel
    {
        public IEnumerable<BookBasicInfoDto> Books { get; set; }
    }
}
