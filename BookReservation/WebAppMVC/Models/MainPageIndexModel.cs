using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
    public class MainPageIndexModel
    {
        public int? Page { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public IEnumerable<BookBasicInfoDto> Books { get; set; }
    }
}
