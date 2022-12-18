using System;
using AutoMapper;
using BL.DTOs;
using BL.DTOs.BasicDtos;
using BL.Services.BookServ;
using Infrastructure.EFCore.UnitOfWork;
using Infrastructure.UnitOfWork;
using BL.Facades.BookFac;
using BL.QueryObjects;
using DAL.Models;
using BL.Services.AuthorServ;
using BL.Services.GenreServ;
using BL.Services.ReservationServ;
using BL.Services.CartItemServ;

namespace BL.Facades.BookFac
{
    public class BookFacade : IBookFacade
    {
        private readonly IBookService bookService;

        private readonly IMapper mapper;

        private readonly IAuthorService authorService;

        private readonly IGenreService genreService;

        private readonly IReservationService reservationService;

        private readonly ICartItemService cartService;

        private readonly IUoWBook uow;

        public BookFacade(IBookService bookService,
            IAuthorService authorService,
            IGenreService genreService,
            IReservationService reservationService,
            ICartItemService cartService,
            IUoWBook uow,
            IMapper mapper)
        {
            this.bookService = bookService;
            this.authorService = authorService;
            this.genreService = genreService;
            this.reservationService = reservationService;
            this.cartService = cartService;
            this.uow = uow;
            this.mapper = mapper;

        }

        public async Task AddBook(BookDto bookDto)
        {
            bookDto.Author = await authorService.GetOrAddAuthor(bookDto.Author.Name);
            bookDto.Genre = await genreService.GetOrAddGenre(bookDto.Genre.Name);
            await bookService.AddBook(bookDto);
        }


        public async Task<bool> UpdateBook(int bookId, BookChangeDto updatedBook)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            var newStock = book.Stock - (updatedBook.Total - book.Total);
            if (newStock < 0)
            {
                return false;
            }
            book.Stock = newStock;
            if (book.Genre.Name != updatedBook.NewGenreName)
            {
                book.Genre = await genreService.GetOrAddGenre(updatedBook.NewGenreName);
            }
            if (book.Author.Name != updatedBook.NewAuthorName)
            {
                book.Author = await authorService.GetOrAddAuthor(updatedBook.NewAuthorName);
            }
            book = mapper.Map(updatedBook, book);
            uow.BookRepository.Update(book);
            await uow.CommitAsync();
            return true;
        }

        public async Task DeleteBook(int bookId)
        {
            Book book = await uow.BookRepository.GetByID(bookId);
            foreach (var rent in book.Rents)
            {
                await reservationService.CancelReservation(rent.Id);
            }
            foreach (var cartItem in book.CartItems)
            {
                await cartService.RemoveItem(cartItem.Id, commit: false);
            }
            book.Deleted = true;
            uow.BookRepository.Update(book);
            await uow.CommitAsync();
        }
    }
}

