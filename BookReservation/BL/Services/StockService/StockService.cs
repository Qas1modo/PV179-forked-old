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
        private BookReservationDbContext context;
        private IMapper mapper;

        public StockService(BookReservationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public QueryResultDto<Book> ShowBooks(BookFilterDto filter)
        {
            IQuery<Book> query = new EFQuery<Book>(context);
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
            using IUoWBook uow = new EFUoWBook(context);
            Book book = uow.BookRepository.GetByID(bookId);
            return mapper.Map<BookAvailabilityDto>(book);
        }

        public bool ReserveBookStock(int bookId)
        {
            using IUoWBook uow = new EFUoWBook(context);
            Book book = uow.BookRepository.GetByID(bookId);
            if (book.Stock < 1) return false;
            book.Stock = book.Stock -= 1;
            uow.BookRepository.Update(book);
            uow.Commit();
            return true;
        }

        public bool BookReturned(int bookId)
        {
            using IUoWBook uow = new EFUoWBook(context);
            Book book = uow.BookRepository.GetByID(bookId);
            if (book.Stock > book.Total) return false;
            book.Stock = book.Stock += 1;
            uow.BookRepository.Update(book);
            uow.Commit();
            return true;
        }
    }
}
