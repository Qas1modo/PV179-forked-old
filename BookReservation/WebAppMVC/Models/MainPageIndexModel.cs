using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
    public class MainPageIndexModel
    {
		public int Page { get; set; }
		public int Total { get; set; }
        public string? GenreFilter { get; set; }
        public string? AuthorFilter { get; set; }
        public string? NameFilter { get; set; }
        public string? OrderBy { get; set; }
        public bool Ascending { get; set; }
        public bool OnStock { get; set; }
        public IEnumerable<BookBasicInfoDto> Books { get; set; }
    }
}
