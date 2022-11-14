namespace BL.DTOs.BasicDtos
{
    public class ReviewDto
    {
        public UserDto User { get; set; }

        public int BookId { get; set; }

        public BookDto Book { get; set; }

        public int Score { get; set; }

        public string? Description { get; set; }
    }
}
