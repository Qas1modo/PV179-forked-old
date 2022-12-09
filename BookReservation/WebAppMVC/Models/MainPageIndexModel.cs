using BL.DTOs;

namespace WebAppMVC.Models
{
    public class MainPageIndexModel
    {
        public IEnumerable<BookBasicInfoDto> Books { get; set; }
    }
}
