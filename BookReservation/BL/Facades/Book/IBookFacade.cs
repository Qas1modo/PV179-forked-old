using System;
using BL.DTOs;

namespace BL.Facades.BookFac
{
    public interface IBookFacade
    {
        BookDetailInfoDto GetBookDetail(int bookId);
    }
}

