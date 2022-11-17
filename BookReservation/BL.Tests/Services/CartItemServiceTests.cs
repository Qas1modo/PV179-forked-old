using AutoMapper;
using BL.DTOs.BasicDtos;
using BL.Services.CartItem;
using DAL.Models;
using Infrastructure.UnitOfWork;

namespace BL.Tests.Services
{
    public class CartItemServiceTests : AbstractTest
    {

        private Mock<IMapper> mapper;
        private Mock<IUoWCartItem> uow;

        public CartItemServiceTests()
        {
            mapper = new Mock<IMapper>();
            uow = new Mock<IUoWCartItem>();

        }

        [Fact]
        public void AddCartItemTest()
        {
            var sampleCartItemDto = new CartItemDto
            {
                UserId = user.Id,
                BookId = book.Id,
                LoanPeriod = 10,
                TotalPrice = book.Price
            };

            mapper.Setup(x => x.Map<CartItem>(It.IsAny<CartItemDto>())).Verifiable();

            uow.Setup(x => x.CartItemRepository.Insert(It.IsAny<CartItem>())).Verifiable(); // do nothing

       
            // HOW??????
            var service = new CartItemService(uow.Object, mapper.Object);

            service.AddItem(sampleCartItemDto);

            mapper.Verify();
            uow.Verify();
        }
    }
}
