using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.QueryObjects;
using BL.Services.WishListItemService;
using DAL.Enums;
using DAL.Models;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.WishListItemServ
{
    public class WishListItemService : IWishListItemService
    {
        private readonly IMapper mapper;
        private readonly IUoWWishList uow;
        private readonly IQuery<WishListItem> query;

        public WishListItemService(IUoWWishList uow,
            IMapper mapper,
            IQuery<WishListItem> query)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.query = query;
        }

        public async Task<bool> AddToWishlist(WishListItemDto input)
        {
            int wishlistCount = uow.WishlistRepository.GetQueryable()
                .Where(x => x.UserId == input.UserId)
                .Where(x => x.BookId == input.BookId)
                .Count();
            if ((await uow.BookRepository.GetByID(input.BookId)).Deleted ||
                wishlistCount > 0)
            {
                return false;
            }
            input.AddedAt = DateTime.Now;
            uow.WishlistRepository.Insert(mapper.Map<WishListItem>(input));
            await uow.CommitAsync();
            return true;
        }

        public async Task DeleteWishlistItem(int id, int userId = -1)
        {
            WishListItem item = await uow.WishlistRepository.GetByID(id);
            if (item.UserId != userId && userId != -1)
            {
                return;
            }
            uow.WishlistRepository.Delete(item);
            await uow.CommitAsync();
        }

        public async Task<QueryResultDto<WishListDetailDto>> GetWishList(int userId, int page = 1)
        {
            query.Where<int>(x => x == userId, "UserId");
            query.OrderBy<DateTime>("AddedAt", false);
            query.Page(page, 15);
            var result = await query.Execute();
            return mapper.Map<QueryResult<WishListItem>, QueryResultDto<WishListDetailDto>>(result);
        }
    }
}
