using DAL.Enums;

namespace BL.DTOs.BasicDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StNumber { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateOnly BirthDate { get; set; }
        public Group Group { get; set; }
        public List<RentDto> Rents { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
