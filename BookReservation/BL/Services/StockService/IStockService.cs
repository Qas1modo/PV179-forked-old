using BL.DTOs.BasicDtos;
using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.DTOs.QueryObjects;
using DAL.Models;

namespace BL.Services.StockService
{
    public interface IStockService
    {
        public QueryResultDto<Book> ShowBooks(BookFilterDto filter);
        public BookAvailabilityDto GetBookStock(int bookId);
        public bool ReserveBookStock(int bookId);
        public bool BookReturnedStock(int bookId);
    }
}
