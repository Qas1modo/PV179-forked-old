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
        Task<QueryResultDto<BookBasicInfoDto>> ShowBooks(BookFilterDto filter);

        Task<bool> ReserveBookStock(int bookId);

        Task<bool> BookReturnedStock(int bookId);
    }
}
