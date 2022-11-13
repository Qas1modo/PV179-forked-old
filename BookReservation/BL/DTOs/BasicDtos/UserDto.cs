using DAL.Enums;

namespace BL.DTOs.BasicDtos
{
    public class UserDto
    {
        public string Name { get; set; }
        
        public AddressDto Address { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public Group Group { get; set; }

        public string Picture { get; set; }

        public List<RentDto> Rents { get; set; }

        public List<ReviewDto> Reviews { get; set; }

        public List<CartItemDto> CartItems { get; set; }
    }
}
