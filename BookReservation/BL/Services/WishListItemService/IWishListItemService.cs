using BL.DTOs;
using BL.DTOs.BasicDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.WishListItemService
{
    public interface IWishListItemService
    {
        Task<bool> AddToWishlist(WishListItemDto input);

        Task DeleteWishlistItem(int id, int userId = -1);

        Task<QueryResultDto<WishListDetailDto>> GetWishList(int userId, int page = 1);
    }
}
