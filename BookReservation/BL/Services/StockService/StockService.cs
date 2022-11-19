using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.DTOs.QueryObjects;
using DAL;
using DAL.Models;
using Infrastructure.EFCore.Query;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.StockService
{
    public class StockService: IStockService
    {
        private readonly IMapper mapper;
        private readonly IUoWBook uow;
        private readonly IQuery<Book> query;

        public StockService(IMapper mapper, IUoWBook uow, IQuery<Book> query)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.query = query;
        }

        public QueryResultDto<Book> ShowBooks(BookFilterDto filter)
        {
            query.Where<bool>(a => a == false, "Deleted");
            if (filter?.OnStock == true)
            {
                query.Where<int>(a => a > 0, "Stock");
            }
            if (filter?.NameFilter != null)
            {
                query.Where<string>(a => a.Contains(filter.NameFilter), "Name");
            }
            if (filter?.AuthorFilter != null)
            {
                query.Where<Author>(a => a.Name == filter.AuthorFilter , "Author");
            }
            if (filter?.GenreFilter != null)
            {
                query.Where<Genre>(a => a.Name == filter.GenreFilter, "Genre");
            }
            if (filter?.OrderBy != null)
            {
                if (filter.OrderBy == "Price")
                {
                    query.OrderBy<decimal>("Price", filter?.Ascending ?? true);
                }
                else if (filter.OrderBy == "Name") 
                {
                    query.OrderBy<string>("Name", filter?.Ascending ?? true);
                }
            }
            if (filter?.Page != null)
            {
                query.Page(filter.Page.Value, filter.PageSize ?? 20);
            }
            return mapper.Map<QueryResultDto<Book>>(query.Execute());
        }

        public BookAvailabilityDto GetBookStock(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            return mapper.Map<BookAvailabilityDto>(book);
        }

        public bool ReserveBookStock(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            if (book.Stock < 1)
            {
                return false;
            }

            book.Stock = book.Stock -= 1;
            uow.BookRepository.Update(book);
            uow.Commit();
            return true;
        }

        public bool BookReturnedStock(int bookId)
        {
            Book book = uow.BookRepository.GetByID(bookId);
            if (book.Stock > book.Total)
            {
                return false;
            }

            book.Stock = book.Stock += 1;
            uow.BookRepository.Update(book);
            uow.Commit();
            return true;
        }
    }
}
