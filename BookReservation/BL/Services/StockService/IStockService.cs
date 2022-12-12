using BL.DTOs.BasicDtos;
using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BL.Services.StockServ
{
    public interface IStockService
    {
        QueryResultDto<BookBasicInfoDto> ShowBooks(BookFilterDto filter);

        BookAvailabilityDto GetBookStock(int bookId);

        bool ReserveBookStock(int bookId);

        bool BookReturnedStock(int bookId);
    }
}
