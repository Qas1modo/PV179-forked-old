using BL.DTOs;
using BL.DTOs.BasicDtos;

namespace WebAppMVC.Models
{
    public class AdminPageAddBookModel
    {
        public AuthorDto Author { get; set; }

        public BookBasicInfoDto Book { get; set; } 

        public GenreDto Genre { get; set; }

        public string GenreName { get; set; } 

        public GenreDto NewGenre { get; set; }

    }
}
